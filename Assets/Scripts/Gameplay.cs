using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{

    FirebaseConfig firebase = new FirebaseConfig();
    private void Awake()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        print("started");
        //so taht imags can be downloaded
        yield return new WaitForSeconds(1f);
        print("wasalt");
        firebase.GetImage();
    }
}
