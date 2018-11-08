using UnityEngine;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

public class LoginDAO : MonoBehaviour
{

	public Login buscarUsuario(Login user)
    {

        try
        {
            string cmd = string.Format("SELECT id,user,password,activo FROM login WHERE user='{0}' and password='{1}'", user.User, user.Pass);
            Conexion conn = GameObject.Find("Controlador").GetComponent<Conexion>();
            MySqlCommand command = new MySqlCommand(cmd, conn.Conectar());
            conn.Abrir();
            MySqlDataReader result = command.ExecuteReader();
           

            Login login = null;
            while (result.Read())
            {


                login.Id = result.GetInt32(0);
                login.User = result.GetString(1);
                login.Pass = result.GetString(2);
                login.Activo = result.GetInt32(3);
                break;
            }
            conn.Cerrar();
            return login;
        }catch (Exception ex){
            return null;
        }

    }


    public bool agregar(Login log)
    {
        try
        {         
            string cmd = string.Format("INSERT INTO  login(user,password,activo) values('{0}','{1}',{2}); ", log.User, log.Pass, log.Activo); 
            Conexion conn = GameObject.Find("Controlador").GetComponent<Conexion>();
            MySqlCommand command = new MySqlCommand(cmd, conn.Conectar());          
            conn.Abrir();
            MySqlDataReader result = command.ExecuteReader();

            while (result.Read())
            {
            }
            conn.Cerrar();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }


    public bool update(Login log)
    {
        try
        {
            string cmd = string.Format("UPDATE login set password='{0}' where id={1} ;", log.Pass, log.Id);
            Conexion conn = GameObject.Find("Controlador").GetComponent<Conexion>();
            MySqlCommand command = new MySqlCommand(cmd, conn.Conectar());           
            conn.Abrir();
            MySqlDataReader result = command.ExecuteReader();

            while (result.Read())
            {
            }
            conn.Cerrar();

            return true;

        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool detele(int id)
    {
        try
        {
            string cmd = string.Format("DELETE FROM  login where id={0}; ",id);
            Conexion conn = GameObject.Find("Controlador").GetComponent<Conexion>();
            MySqlCommand command = new MySqlCommand(cmd, conn.Conectar());           
            conn.Abrir();
            MySqlDataReader result = command.ExecuteReader();

            while (result.Read())
            {
            }
            conn.Cerrar();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public List<Login> buscarTodo()
    {

        List<Login> logins= new List<Login>();
        try
        {
           
            string cmd = string.Format("SELECT id,user,password,activo FROM login ;");
            Conexion conn = GameObject.Find("Controlador").GetComponent<Conexion>();
            MySqlCommand command = new MySqlCommand(cmd, conn.Conectar());
            conn.Abrir();
            MySqlDataReader result = command.ExecuteReader();
            while (result.Read())
            {
                //username = result["user"].ToString();
                //password = result["password"].ToString();

                Login login = null;

                login.Id = result.GetInt32(0);
                login.User= result.GetString(1);
                login.Pass= result.GetString(2);
                login.Activo = result.GetInt32(3);

                logins.Add(login);                
            }
            conn.Cerrar();
            return logins;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
