using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine.UI;
using TMPro;

public class StartButtonScript : MonoBehaviour
{
    [SerializeField] GameObject usernameField;

    string lobby = "1";
    string username;

    public void OnStartButton()
    {
        if (GetUsername())
        {
            FirebaseConfig firebase = new FirebaseConfig();
            firebase.SendPlayerData(lobby, "1", new PlayerDetails(username, "square", "20", "riught now", "testing"));
        }
    }

    private bool GetUsername()
    {
        username = usernameField.transform.GetChild(0).GetComponent<TMP_InputField>().text;

        if(username.Length >= 3)
        {
            print("Username valid");
            return true;
        }
        else
        {
            print("username invalid");
            return false;
        }
    }
 
}
