using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionPersist : MonoBehaviour
{


    private void Awake()
    {


        int numSessionPersist = FindObjectsOfType<SessionPersist>().Length;
        if (numSessionPersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
