using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Storage;
using Firebase.Extensions;
using UnityEngine.UI;

public class FirebaseConfig : MonoBehaviour
{
    DatabaseReference dr;

    public void SendPlayerData(string lobbyNum, string playerNum, PlayerDetails player)
    {
        dr = FirebaseDatabase.DefaultInstance.RootReference;
        string json = JsonUtility.ToJson(player);
        dr.Child("Lobby " + lobbyNum).Child("Player " + playerNum).SetRawJsonValueAsync(json);
        print("wokring");

    }

    public void GetImage(string url,  img)
    {
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;
        StorageReference sr = storage.GetReferenceFromUrl(url);

        sr.GetBytesAsync(long.MaxValue).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogException(task.Exception);
            }
            else
            {
                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(task.Result);
                img.texture = texture;
            }
        });
    }
}
