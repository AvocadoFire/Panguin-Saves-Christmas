using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsMechanics : MonoBehaviour
{
    [SerializeField] GameObject giftParticle;
    [SerializeField] AudioClip giftPickupSFX;
   // [SerializeField] int giftWorth = 1;

    bool wasCollected = false;
    GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!wasCollected)
        {
        wasCollected = true;
        Instantiate(giftParticle, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(giftPickupSFX, Camera.main.transform.position);
        Destroy(gameObject);
     //   gameSession.AddToScore(giftWorth);
        }
    }
}
