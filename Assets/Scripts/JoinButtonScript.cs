using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine.SceneManagement;
using TMPro;

public class JoinButtonScript : MonoBehaviour
{

    [SerializeField] private TMP_InputField usernameField;

    string lobby = "1";
    public string username;
    Vector2 pos = new Vector2(0f, 5f);

    FirebaseConfig config;
    // Start is called before the first frame update
    void Start()
    {
        config = new FirebaseConfig();
    }

   public void OnJoinGame()
    {
        username = usernameField.text;
        FirebaseDatabase.DefaultInstance.GetReference("Lobby " + lobby).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if(task.Result.Value != null)
            {
                config.SendPlayerData(lobby, "2", new PlayerDetails(username, "Red Square", pos, ""));
                GameManager.lobbyNum = lobby;
                GameManager.player = "2";
                SceneManager.LoadScene("Game");
            }
            else
            {
                print("did not work");
            }
        });
    }
}
