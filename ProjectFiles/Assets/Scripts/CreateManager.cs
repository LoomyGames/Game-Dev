using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager; //the inventory manager from the current scene
    private Animator anim;
    [SerializeField]
    private Camera animCam; //animation camera for when leaving the levels scenes
    private Camera mainCam;
    private CharacterController CC; 
    // Start is called before the first frame update
    void Awake()
    {
        CC = GameObject.FindWithTag("Player").GetComponent<CharacterController>(); // initialize all of the variables
        anim = animCam.GetComponent<Animator>();
        mainCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        if (GameObject.FindWithTag("Inventory Manager") == null) // this only happens the first time the main lobby is loaded, when there is no game manager in the scene
        {
            Instantiate(gameManager); // instantiate the game manager (inventory manager)
        } else //if there already is a game manager that means the player just left one of the levels and is returning to the lobby
        {
            GameObject.FindWithTag("Inventory Manager").GetComponent<InventoryManager>().FindBuildings(); //therefore find and upgrade the buldings accordingly
            GameObject.FindWithTag("Inventory Manager").GetComponent<InventoryManager>().GenerateUpgrades();
            mainCam.enabled = false; //disable everything related to the player to allow for the return animation to play
            CC.enabled = false;
            animCam.enabled = true;
            anim.Play("CameraHover");
            StartCoroutine(waitForAnim());
        } 
    }

    IEnumerator waitForAnim() //a wait time method that waits for 4 seconds while the animation plays before enabling the player controller again
    {
        yield return new WaitForSeconds(4);
        mainCam.enabled = true;
        CC.enabled = true;
        animCam.enabled = false;
    }

}
