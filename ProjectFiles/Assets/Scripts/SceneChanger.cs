using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public string sceneName = "";// the name of the scene this trigger will mvoe the player to (level 1, 2, 3 etc.)

    private void OnTriggerEnter(Collider other) //upon entering the trigger, the player is sent to the new scene, if the name is not null (for safety purposes)
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
