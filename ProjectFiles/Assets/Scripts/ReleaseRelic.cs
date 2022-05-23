using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReleaseRelic : MonoBehaviour
{
    [SerializeField]
    int buildingsDestroyed = 0; //the number of buildings currently destroyed
    [SerializeField]
    int buildingsRequired = 0; //the number of destroyed buildings required (in the demo it's 5, but that can be adjusted or even randomized in the future)
    public GameObject relic;
    EnterPlane plane;
    Text finishText;

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.FindWithTag("Plane").GetComponent<EnterPlane>();//get the plane controller (for setting the collectedRelic boolean upon completion
        finishText = GameObject.Find("DialogueText").GetComponent<Text>();
        finishText.text = "Quick, get in the plane and destroy the buildings to collect the relic!"; //instructions text shown when first loading into the level 
        StartCoroutine(resetText()); //another text reset coroutine
    }

    public void BuildingDestroyed() //method that gets called whenever a building is destroyed
    {
        buildingsDestroyed++;
        if(buildingsDestroyed == buildingsRequired)//upon destroying the final one required, the relic is spawned and the player can land
        {
            relic.SetActive(true);
            plane.collectedRelic = true; //setting the plane controller boolean to true
            Debug.Log("Relic can be collected");
            finishText.text ="Good job! " + relic.GetComponent<CollectedObject>().objName + " can be collected, press E to land!"; //instructions for the player
            StartCoroutine(resetText());
        }
    }

    IEnumerator resetText() // the text reset coroutine
    {
        yield return new WaitForSeconds(2.5f);
        finishText.text = "";
    }
}
