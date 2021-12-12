using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Firebase.Storage;
using Firebase.Extensions;
using Firebase.Database;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    
    FirebaseConfig firebase = new FirebaseConfig();
    public static float totalDist;
    public static int totalPoints;
    public Vector2 prevLocation;

    private void Awake()
    {
        StartCoroutine(StartGame());
        Debug.Log(totalDist);
        Debug.Log(totalPoints);
        Debug.Log(prevLocation);

    }

    private void Update()
    {
        StartCoroutine(Distance());
    }

    IEnumerator StartGame()
    {
        //so taht imags can be downloaded
        yield return new WaitForSeconds(1f);

    }

     IEnumerator Distance()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log(totalDist);
        Debug.Log(totalPoints);
        Debug.Log(prevLocation);
        totalDist += Vector2.Distance(transform.position, prevLocation);
        prevLocation = transform.position;
        totalPoints = (int)Math.Round(totalDist / 10);
        GameObject.Find("Player1").GetComponent<TMP_Text>().text = "P1: " + totalPoints.ToString();
        print("Hello");
    }

    public void GameMechanics()
    {
        if(totalPoints == 10)
        {
            SceneManager.LoadScene("End");
        }
       
    }
}
