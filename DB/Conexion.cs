using UnityEngine;
using MySql.Data.MySqlClient;

public class Conexion : MonoBehaviour {

    public string servidorDB;
    public string nombreDB;
    public string userDB;
    public string passDB;

    //Conexion Base de datos
    private string datosConexion;
    private MySqlConnection conexion;

    // Use this for initialization  
    void Start() {
        datosConexion = "Server=" + servidorDB
                  + ";Database=" + nombreDB
                  + ";Uid=" + userDB
                  + ";Pwd=" + passDB
                  + ";";
        Conectar();
	}

    public MySqlConnection Conectar()
    {       
        conexion = new MySqlConnection(datosConexion);
        return conexion;
    }

    public void Abrir()
    {
        try
        {
            conexion.Open();
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Error " + ex.Message);
        }
    }


    public void Cerrar()
    {
        try
        {
            conexion.Close();
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Error " + ex.Message);
        }
    }

    public MySqlDataReader Select(string _select)
    {
        MySqlCommand cmd = conexion.CreateCommand();
        cmd.CommandText = "SELECT  " + _select;
        MySqlDataReader result = cmd.ExecuteReader();
        return result;
    }


    public bool Cone()
    {
        bool conectado = false;
        try
        {
            conexion.Open();
            conectado = true;
        }
        catch (MySqlException ex)
        {
            conectado = false;
        }
        finally
        {
            conexion.Close();
        }

        return conectado;
    }
    public bool insertar(string consulta)
    {
        bool agregado = false;
        int rows = 0;
        conexion.Open();
        MySqlCommand cmd = new MySqlCommand(consulta, conexion);
        rows = cmd.ExecuteNonQuery();
        if (rows>0)
        {
            agregado = true;
        }
        conexion.Close();
        return agregado;

    }
}
