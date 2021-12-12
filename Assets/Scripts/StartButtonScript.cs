using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameField;

    string lobby = "1";
    string username;
    Vector2 pos = new Vector2(0f, 5f);
    string timeCreated;
    string uid;

    public void OnStartButton()
    {
            username = usernameField.text;
            FirebaseConfig firebase = new FirebaseConfig();
            firebase.SendPlayerData(lobby, "1", new PlayerDetails(username, "Blue Circle", pos, "right now", "testing", ""));
            SceneManager.LoadScene("Game");
            print("uploading");
    }
 
}
