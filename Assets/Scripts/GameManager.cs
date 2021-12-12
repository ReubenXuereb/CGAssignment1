using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Firebase.Storage;
using Firebase.Extensions;
using Firebase.Database;

public class GameManager : MonoBehaviour
{
    
    FirebaseConfig firebase = new FirebaseConfig();
    public static float totalDist = 0;
    public static int totalPoints = 0;
    public Vector2 prevLocation;

    private void Awake()
    {
        StartCoroutine(StartGame());
    }

    private void Update()
    {
        Distance();
    }

    IEnumerator StartGame()
    {
        //so taht imags can be downloaded
        yield return new WaitForSeconds(1f);

    }

    private void Distance()
    {
        totalDist += Vector2.Distance(transform.position, prevLocation);
        prevLocation = transform.position;
        totalPoints = (int)Mathf.Round(totalDist / 10);
        GameObject.Find("Player1").GetComponent<TMP_Text>().text = "P1: " + totalPoints.ToString();
    }

    public void GameMechanics()
    {
        
       
    }
}
