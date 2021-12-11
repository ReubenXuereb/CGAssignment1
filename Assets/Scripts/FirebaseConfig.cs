using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Storage;
using Firebase.Extensions;

public class FirebaseConfig : MonoBehaviour
{
    DatabaseReference dr;

    public void SendPlayerData(string lobbyNum, string playerNum, PlayerDetails player)
    {
        dr = FirebaseDatabase.DefaultInstance.RootReference;
        string json = JsonUtility.ToJson(player);
        dr.Child("Lobby " + lobbyNum).Child("Player " + playerNum).SetRawJsonValueAsync(json);

    }
}
