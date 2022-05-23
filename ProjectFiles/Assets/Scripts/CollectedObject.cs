using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedObject : MonoBehaviour
{
    [SerializeField]
    public string objName = "";
    enum UpgradeName //an enum holding what type of upgrade this relic gives
    {
        Airport,
        Runway,
        Warehouse
    };
    [SerializeField]
    UpgradeName upgrade; //the actual reference to the upgrade
    InventoryManager IM; //reference to the inventory manager controller
    Text pickText;
    // Start is called before the first frame update
    void Start()
    {
        IM = GameObject.FindWithTag("Inventory Manager").GetComponent<InventoryManager>(); //initializing the variables
        pickText = GameObject.FindWithTag("DialogueText").GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other) //when the player enters the trigger of this relic
    {
        if(other.CompareTag("Player"))
        {
            pickText.text = "Collected " + objName; //state that it has been collected
            pickText.GetComponent<ResetText>().ResetWriting(); //after a couple of seconds hide the collection text
            IM.IncreaseBuildingLevel(upgrade.ToString()); // increase the level of the building this upgrade was for 
            Destroy(gameObject); // destroy the gameobject
        }
    }
}
