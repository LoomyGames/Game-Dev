using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public string sceneName = "";

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(sceneName!= null)
            {
                Debug.Log("Loading Scene...");
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
