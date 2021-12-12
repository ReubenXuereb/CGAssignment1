using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Storage;
using Firebase.Extensions;

public class GetImage : MonoBehaviour
{



    void Start()
    {
        
        StartCoroutine(loadImages());

    }

    IEnumerator loadImages()
    {
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;
        StorageReference sr = storage.GetReferenceFromUrl("gs://cgassignment1.appspot.com/");
        StorageReference img1 = sr.Child("BlueCircle.png");
        StorageReference img2 = sr.Child("RedSquare.png");
        StartCoroutine(GetImages(img1));
        StartCoroutine(GetRedImage(img2));
        yield return new WaitForSeconds(0f);
    }
    
    IEnumerator GetImages(StorageReference reference)
    {
        yield return new WaitForSeconds(0f);
        const long maxAllowedSize = 1 * 1024 * 1024;
        reference.GetBytesAsync(maxAllowedSize).ContinueWithOnMainThread(task => {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogException(task.Exception);
            }
            else
            {
               
                byte[] fileContents = task.Result;

                
                Texture2D texture = new Texture2D(1024, 1024);
                texture.LoadImage(fileContents);

                print("hawn wasalt zgur");
                Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                GameObject Player1 = new GameObject();
                Player1.gameObject.transform.localScale = new Vector2(0.3f, 0.3f);
                Player1.transform.position = new Vector2(-3f, 0f);
                Player1.AddComponent<SpriteRenderer>().sprite = sprite;
                Player1.AddComponent<Rigidbody2D>().gravityScale = 0;
                Player1.AddComponent<PlayerMovment>();
                //Player1.AddComponent<GameManager>();
                Player1.name = "Player 1";
                print("hawn wasalt zgur wkoll");
                Debug.Log("Finished downloading!");
            }
        });

    }

    IEnumerator GetRedImage(StorageReference reference)
    {
        yield return new WaitForSeconds(0f);
        const long maxAllowedSize = 1 * 1024 * 1024;
        reference.GetBytesAsync(maxAllowedSize).ContinueWithOnMainThread(task => {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogException(task.Exception);
            }
            else
            {

                byte[] fileContents = task.Result;


                Texture2D texture = new Texture2D(1024, 1024);
                texture.LoadImage(fileContents);

               
                Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                GameObject Player2 = new GameObject();
                Player2.gameObject.transform.localScale = new Vector2(0.3f, 0.3f);
                Player2.transform.position = new Vector2(3f, 0f);
                Player2.AddComponent<SpriteRenderer>().sprite = sprite;
                Player2.AddComponent<Rigidbody2D>().gravityScale = 0;
                Player2.AddComponent<PlayerMovment>();
                //Player1.AddComponent<GameManager>();
                Player2.name = "Player 2";
            }
        });
    }
}
