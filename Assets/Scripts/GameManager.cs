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

    public static string player = "1";
    public static string lobbyNum = "1";

    PlayerMovment pm;

    /* public static float totalDistP1;
     public static int totalPointsP1;
     public Vector2 prevLocationP1;

     public static float totalDistP2;
     public static int totalPointsP2;
     public Vector2 prevLocationP2;*/
    public int player1Moves = 0;
    public int player2Moves = 0;
    public int totalPointsP1 = 0;
    public int totalPointsP2 = 0;
    public string winnerP1 = "Player 1 is the winner";
    public string winnerP2 = "Player 2 is the winner";

    private void Awake()
    {
        dontDestroyGM();
        StartCoroutine(StartGame());
        /*Debug.Log(totalDist);
        Debug.Log(totalPoints);
        Debug.Log(prevLocation);*/

    }
    private void dontDestroyGM()
    {
        int numberOfGameManagers = FindObjectsOfType<GameManager>().Length;
        if (numberOfGameManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        GameMechanics();
    }

    IEnumerator StartGame()
    {
        //so taht imags can be downloaded
        yield return new WaitForSeconds(1f);
       

    }

   private void GameMechanics()
    {
        /*Debug.Log(totalDistP1);
        Debug.Log(totalPointsP1);
        Debug.Log(prevLocationP1);
        totalDistP1 += Vector2.Distance(GameObject.Find("Player 1").transform.position, prevLocationP1); 
        prevLocationP1 = GameObject.Find("Player 1").transform.position;       
        totalPointsP1 = (int)Mathf.Round(totalDistP1 / 10);      
        GameObject.Find("Player1").GetComponent<TMP_Text>().text = "P1: " + totalPointsP1.ToString();
        print("Hello");
        print("thalt hawn");
        if (pm.p1NumOfMoves >= 10)
        {
            totalPointsP1++;
            pm.p1NumOfMoves = 0;
            GameObject.Find("Player1").GetComponent<TMP_Text>().text = "P1: " + totalPointsP1.ToString();
            //totalPointsP2++;
            //GameObject.Find("Player2").GetComponent<TMP_Text>().text = "P2: " + totalPointsP1.ToString();
        }
        else
        {
            print("mhux nahdem");
        }*/

        if(GameObject.Find("Player 1").GetComponent<PlayerMovment>().p1NumOfMoves >= 10)
        {
            GameObject.Find("Player 1").GetComponent<PlayerMovment>().p1NumOfMoves = 0;
            GameObject.Find("Player 1").GetComponent<PlayerMovment>().p1Score++;
            GameObject.Find("Player1").GetComponent<TMP_Text>().text = "P1: " + GameObject.Find("Player 1").GetComponent<PlayerMovment>().p1Score.ToString();
        }

        if (GameObject.Find("Player 2").GetComponent<PlayerMovment>().p2NumOfMoves >= 10)
        {
            GameObject.Find("Player 2").GetComponent<PlayerMovment>().p2NumOfMoves = 0;
            GameObject.Find("Player 2").GetComponent<PlayerMovment>().p2Score++;
            GameObject.Find("Player2").GetComponent<TMP_Text>().text = "P2: " + GameObject.Find("Player 2").GetComponent<PlayerMovment>().p2Score.ToString();
        }

        if (GameObject.Find("Player 1").GetComponent<PlayerMovment>().p1Score == 2)
        {
            SceneManager.LoadScene("End");
            Debug.Log(winnerP1);
            GameObject.FindWithTag("WinnerText").GetComponent<TMP_Text>().text = winnerP1;
        }

        if (GameObject.Find("Player 2").GetComponent<PlayerMovment>().p2Score == 2)
        {
            SceneManager.LoadScene("End");
            Debug.Log(winnerP2);
            GameObject.FindWithTag("WinnerText").GetComponent<TMP_Text>().text = winnerP2;
        }

    }

   /* private void Distance2()
    {
        Debug.Log(totalDistP1);
        Debug.Log(totalPointsP1);
        Debug.Log(prevLocationP1);
        totalDistP2 += Vector2.Distance(GameObject.Find("Player 2").transform.position, prevLocationP2);
        prevLocationP2 = GameObject.Find("Player 2").transform.position;
        totalPointsP2 = (int)Mathf.Round(totalDistP2 / 10);
        GameObject.Find("Player2").GetComponent<TMP_Text>().text = "P2: " + totalPointsP1.ToString();
        print("Hello");
    }*/
}
