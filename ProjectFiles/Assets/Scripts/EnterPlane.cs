using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterPlane : MonoBehaviour
{
    GameObject player; // player and plane related variables needed for switching controllers
    public GameObject planeCam;
    public Transform animCamPos;
    public bool inPlane = false;
    bool inRange = false;
    public bool collectedRelic = false;
    public GameObject planeClone;
    public GameObject planeMesh;

    private Text interactText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player"); // find variables
        planeCam.SetActive(false);
        interactText = GameObject.FindWithTag("DialogueText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E)) //if the player presses E
        {
            if (inPlane && collectedRelic) // only if the player is in the plane and has collected the relic can they leave 
            {
                Debug.Log("Exited Plane");
                StartCoroutine(WaitForAnim()); //another coroutine for waiting to enable the player only after the animation finished
                GetComponent<PlaneController>().enabled = false; //disable the plane systems
                GetComponent<PlaneShooting>().enabled = false;
                planeCam.transform.position = animCamPos.position;
                planeCam.transform.rotation = animCamPos.rotation;
                inPlane = false;
                planeClone.SetActive(true); //enable the clone mesh of the plane that actually plays the animation
                //planeClone.GetComponent<Animator>().Play("PlaneLand");
                planeMesh.SetActive(false); //disable the mesh of the actual flown plane
            } else if(!inPlane && inRange) // otherwise, the player can enter the plane if in range
            {
                interactText.text = ""; //the exact opposite, enable the plane systems and disable the player ones
                Debug.Log("Entered plane");
                player.SetActive(false);
                GetComponent<PlaneController>().enabled = true;
                GetComponent<PlaneShooting>().enabled = true;
                planeCam.SetActive(true);
                inPlane = true;
                inRange = false;
            }
        }
    }

    private void OnTriggerStay(Collider other) //while in the trigger range of the plane, the player can enter if they press E and a prompt appears
    {
        if (other.gameObject == player)
        {
            inRange = true;
            interactText.text = "Press E";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player) // as soon as the player leaves this range, the prompt disappears and the plane can not be entered
        {
            inRange = false;
            interactText.text = "";
        }
    }

    IEnumerator WaitForAnim()//the coroutine that controls the wait time for the landing animation
    {
        yield return new WaitForSeconds(3);
        player.SetActive(true);
        planeCam.SetActive(false);
    }
}
