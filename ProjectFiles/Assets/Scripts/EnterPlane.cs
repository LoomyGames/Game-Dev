using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterPlane : MonoBehaviour
{
    GameObject player;
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
        player = GameObject.FindWithTag("Player");
        planeCam.SetActive(false);
        interactText = GameObject.FindWithTag("DialogueText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inPlane && collectedRelic)
            {
                Debug.Log("Exited Plane");
                StartCoroutine(WaitForAnim());
                GetComponent<PlaneController>().enabled = false;
                GetComponent<PlaneShooting>().enabled = false;
                planeCam.transform.position = animCamPos.position;
                planeCam.transform.rotation = animCamPos.rotation;
                inPlane = false;
                planeClone.SetActive(true);
                //planeClone.GetComponent<Animator>().Play("PlaneLand");
                planeMesh.SetActive(false);
            } else if(!inPlane && inRange)
            {
                interactText.text = "";
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            inRange = true;
            interactText.text = "Press E";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            inRange = false;
            interactText.text = "";
        }
    }

    IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(3);
        player.SetActive(true);
        planeCam.SetActive(false);
    }
}
