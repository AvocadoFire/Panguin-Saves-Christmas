using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
  //  [SerializeField] GameObject giftParticle;
   // [SerializeField] AudioClip giftPickupSFX;
    [SerializeField] LevelLoader levelLoader;
   // [SerializeField] int giftWorth = 1;

//    GameSession gameSession;

    private void Start()
    {
  //      gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
   //     Instantiate(giftParticle, transform.position, Quaternion.identity);
    //    AudioSource.PlayClipAtPoint(giftPickupSFX, Camera.main.transform.position);
        Destroy(gameObject);
        levelLoader.LoadNextScene();

   //     gameSession.AddToScore(giftWorth);
    }
}
