using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private GameObject Airport; //the parents of each group of upgrades
    private GameObject Runway;
    private GameObject Warehouse;

    int airportLevel = -1; //the levels of the groups (starting with -1 for not even being built)
    int runwayLevel = -1;
    int warehouseLevel = -1;

    // Start is called before the first frame update
    void Start()
    {
        FindBuildings(); //upon entering the scene, find the buildings and don't destroy the object after leaving the scene
        DontDestroyOnLoad(gameObject); //this object follows the player throughout the levels and updates constantly
    }

    public void FindBuildings() //find the upgrade groups' parents
    {
        Airport = GameObject.FindWithTag("Airport");
        Runway = GameObject.FindWithTag("Runway");
        Warehouse = GameObject.FindWithTag("Warehouse");

    }

    public void UpgradeBuilding(string name) //upgrade the building based on the collected relic, method called when switching the scene from a level to the lobby
    {
        if (name == "Airport") //if the building name is Airport, find all of the children groups and enable them based on how many levels the manager has
        {
            int i = 0;
            foreach (Transform child in Airport.transform) //this sets the groups active on each load into the lobby based on the current group level
            {
                if (i <= airportLevel)
                {
                    child.gameObject.SetActive(true);
                    i++;
                }
            }
        }
        else if (name == "Warehouse") //this is the same as above, only for the Warehouse group
        {
            int i = 0;
            foreach (Transform child in Warehouse.transform)
            {
                if (i <= warehouseLevel)
                {
                    child.gameObject.SetActive(true);
                    i++;
                }
            }
        }
        else if (name == "Runway") //this is the same as above, only for the Runway group
        {
            int i = 0;
            foreach (Transform child in Runway.transform)
            {
                if (i <= runwayLevel)
                {
                    child.gameObject.SetActive(true);
                    i++;
                }
            }
        }
    }

    public void IncreaseBuildingLevel(string name) //this method is called when picking up a relic and increases the level of the specified group
    {
        if (name == "Airport") //all of the statements here work the same, but for the 3 different groups
        {
            if (airportLevel < 3)
            {
                airportLevel++;
            }
            else
            { //the max level of each group is 3, but this can be easily scaled up indefinitely
                airportLevel = 3;
                Debug.Log("Airport at max level");
            }
        }
        else if (name == "Warehouse")
        {
            if (warehouseLevel < 3)
            {
                warehouseLevel++;
            }
            else
            {
                warehouseLevel = 3;
                Debug.Log("Warehouse at max level");
            }
        }
        else if (name == "Runway")
        {
            if (runwayLevel < 3)
            {
                runwayLevel++;
            }
            else
            {
                runwayLevel = 3;
                Debug.Log("Runway at max level");
            }
        }
    }

    public void GenerateUpgrades() // generate the upgrades, method called when entering the lobby again after leaving a level
    {
        UpgradeBuilding("Airport");
        UpgradeBuilding("Warehouse");
        UpgradeBuilding("Runway");
    }
}
