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
        StorageReference img = sr.Child("BlueCircle.png");
        StartCoroutine(GetImages(img));
        yield return new WaitForSeconds(1f);
    }
    
    IEnumerator GetImages(StorageReference reference)
    {
        yield return new WaitForSeconds(1.5f);
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
                Player1.name = "Player 1";
                print("hawn wasalt zgur wkoll");
                Debug.Log("Finished downloading!");
            }
        });

    }
}
