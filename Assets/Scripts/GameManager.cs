using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Storage;
using Firebase.Extensions;
using Firebase.Database;

public class GameManager : MonoBehaviour
{
    FirebaseConfig firebase = new FirebaseConfig();

    private void Awake()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        //so taht imags can be downloaded
        yield return new WaitForSeconds(1f);

    }

    public void GameMechanics()
    {
        //when player moves 10 times add 1 point
       
    }
}
