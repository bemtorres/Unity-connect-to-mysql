using UnityEngine;
using System.Security.Cryptography;
using System.Text;

public class Encryptador : MonoBehaviour {

    public string encryptar(string pass)
    {
        SHA256 sha256 = SHA256Managed.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(pass);
        byte[] hash = sha256.ComputeHash(bytes);
        return getString(hash);
    }

    private string getString(byte[] hash)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            result.Append(hash[i].ToString("X2"));
        }
        return result.ToString().ToLower();
    }
}


