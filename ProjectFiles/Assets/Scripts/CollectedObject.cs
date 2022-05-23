using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedObject : MonoBehaviour
{
    [SerializeField]
    public string objName = "";
    enum UpgradeName
    {
        Airport,
        Runway,
        Warehouse
    };
    [SerializeField]
    UpgradeName upgrade;
    InventoryManager IM;
    Text pickText;
    // Start is called before the first frame update
    void Start()
    {
        IM = GameObject.FindWithTag("Inventory Manager").GetComponent<InventoryManager>();
        pickText = GameObject.FindWithTag("DialogueText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            pickText.text = "Collected " + objName;
            pickText.GetComponent<ResetText>().ResetWriting();
            IM.IncreaseBuildingLevel(upgrade.ToString());
            Destroy(gameObject);
        }
    }
}
