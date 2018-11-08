using UnityEngine;

public class Login : MonoBehaviour {

    public int Id { get; set; }
    public string User { get; set; }
    public string Pass { get; set; }
    public int Activo { get; set; }

    public Login()
    {
        Id = 0;
        User = "";
        Pass = "";
        Activo = 0;
    }

    public Login(int id, string user, string pass, int activo)
    {
        this.Id =   id;
        this.User = user;
        this.Pass = pass;
        this.Activo = activo;
    }

    public void imprimir()
    {
        Debug.Log(string.Format("id {0} , usuario {1} , pass {2} , activo {3} ", Id, User, Pass, Activo));
    }

    public string str()
    {
        return string.Format("id {0} , usuario {1} , pass {2} , activo {3} ", Id,User,Pass,Activo) ;
    }
}
