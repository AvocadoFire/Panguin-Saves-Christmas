using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] GameObject exitParticle;
    [SerializeField] AudioClip exitPickupSFX;
    [SerializeField] LevelLoader levelLoader;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(exitParticle, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(exitPickupSFX, Camera.main.transform.position);
        other.gameObject.SetActive(false);
        Invoke("NextScene", 1);
    }

    void NextScene()
    {
        FindObjectOfType<SessionPersist>().ResetScenePersist();
        levelLoader.LoadNextScene();

    }

}
