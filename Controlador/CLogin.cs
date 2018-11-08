using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class CLogin : MonoBehaviour {

    public InputField username;
    public InputField pass;

    public InputField username1;
    public InputField pass1;
    public InputField id1;

    public Text texto;

    public void Acceder()
    {
            Login login = null;
            Login us = new Login();
        
            if (username.text.Trim().Length > 0 && pass.text.Trim().Length > 0)
            {
                us.Pass = (new Encryptador()).encryptar(pass.text);
                us.User = username.text;

                login = (new LoginDAO()).buscarUsuario(us);

                Debug.Log("login es == " + (login == null));
                Debug.Log("login es ! " + (login != null));
                Debug.Log("login es ! " + (login.GetType() == typeof(Login)));
        }
            else
            {
                Debug.Log("Ingrese datos");
                texto.text = "Ingrese datos";
            }
       
      
    }
    public void Agregar()
    {
        int id = Convert.ToInt32(id1.text);
        string user = username1.text;
        string pass = (new Encryptador()).encryptar(pass1.text);

        Login log = new Login(id, user, pass,1);

        bool estado = (new LoginDAO()).Agregar(log);

        if (estado)
        {
            texto.text = "Agregado";        }
        else
        {
            texto.text = "No Agregado";
        }

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
