using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    GameObject player1;
    GameObject player2;

    public int p1NumOfMoves = 0;
    public int p2NumOfMoves = 0;

    public int p1Score = 0;
    public int p2Score = 0;

    // Update is called once per frame
    void Update()
    {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");


        if (Input.GetKeyDown(KeyCode.A))
        {
            player1.transform.position -= new Vector3(1f, 0f);
            p1NumOfMoves++;
            print(p1NumOfMoves);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            player1.transform.position += new Vector3(1f, 0f);
            p1NumOfMoves++;
            print(p1NumOfMoves);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            player2.transform.position += new Vector3(0f, 1f);
            p2NumOfMoves++;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            player2.transform.position -= new Vector3(0f, 1f);
            p2NumOfMoves++;
        }

       /* if(p1NumOfMoves >= 10)
        {
            p1Score++;
            p1NumOfMoves = 0;
            GameObject.Find("Player1").GetComponent<TMP_Text>().text = "P1: " + p1Score.ToString();
        }

        if (p2NumOfMoves >= 10)
        {
            p2Score++;
            p2NumOfMoves = 0;
            GameObject.Find("Player2").GetComponent<TMP_Text>().text = "P2: " + p2Score.ToString();
        }

        else if ((p1Score == 10) || (p2Score == 10))
        {
            SceneManager.LoadScene("End");
        }*/
    }

    
}
