using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReleaseRelic : MonoBehaviour
{
    [SerializeField]
    int buildingsDestroyed = 0;
    [SerializeField]
    int buildingsRequired = 0;
    public GameObject relic;
    EnterPlane plane;
    Text finishText;

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.FindWithTag("Plane").GetComponent<EnterPlane>();
        finishText = GameObject.Find("DialogueText").GetComponent<Text>();
        finishText.text = "Quick, get in the plane and destroy the buildings to collect the relic!";
        StartCoroutine(resetText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildingDestroyed()
    {
        buildingsDestroyed++;
        if(buildingsDestroyed == buildingsRequired)
        {
            relic.SetActive(true);
            plane.collectedRelic = true;
            Debug.Log("Relic can be collected");
            finishText.text ="Good job! " + relic.GetComponent<CollectedObject>().objName + " can be collected, press E to land!";
            StartCoroutine(resetText());
        }
    }

    IEnumerator resetText()
    {
        yield return new WaitForSeconds(2.5f);
        finishText.text = "";
    }
}
