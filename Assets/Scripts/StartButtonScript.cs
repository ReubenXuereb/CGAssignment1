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
    public string username;
    Vector2 pos = new Vector2(0f, 5f);

    public void OnStartButton()
    {
            username = usernameField.text;
            FirebaseConfig firebase = new FirebaseConfig();
            firebase.SendPlayerData(lobby, "1", new PlayerDetails(username, "Blue Circle", pos, ""));
            StartCoroutine(Player2Joined());
            print("uploading");
    }

    IEnumerator Player2Joined()
    {
        while (true)
        {
            FirebaseDatabase.DefaultInstance.GetReference("Lobby " + lobby).GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if(task.Result.HasChild("Player 2"))
                {
                    GameManager.player = "1";
                    GameManager.lobbyNum = lobby;
                    SceneManager.LoadScene("Game");
                }
            });

            yield return new WaitForSeconds(1f);
        }
    }
 
}
