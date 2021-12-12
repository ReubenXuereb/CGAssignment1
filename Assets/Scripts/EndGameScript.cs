using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{


    public void EndGame() {
        if (GameObject.Find("Player 1").GetComponent<PlayerMovment>().p1Score == 2)
        {
            SceneManager.LoadScene("");
        }
     }
}
