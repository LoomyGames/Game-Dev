using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private int currency = 0;

    private GameObject Airport;
    private GameObject Runway;
    private GameObject Warehouse;

    int airportLevel = -1;
    int runwayLevel = -1;
    int warehouseLevel = -1;

    // Start is called before the first frame update
    void Start()
    {
        FindBuildings();
        DontDestroyOnLoad(gameObject);
    }

    public void FindBuildings()
    {
        Airport = GameObject.FindWithTag("Airport");
        Runway = GameObject.FindWithTag("Runway");
        Warehouse = GameObject.FindWithTag("Warehouse");

    }

    public int GetCurrency()
    {
        return currency;
    }

    public void UpgradeBuilding(string name)
    {
        if (name == "Airport")
        {
            int i = 0;
            foreach (Transform child in Airport.transform)
            {
                if (i <= airportLevel)
                {
                    child.gameObject.SetActive(true);
                    i++;
                }
            }
        }
        else if (name == "Warehouse")
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
        else if (name == "Runway")
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

    public void IncreaseBuildingLevel(string name)
    {
        if (name == "Airport")
        {
            if (airportLevel < 3)
            {
                airportLevel++;
            }
            else
            {
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

    public void GenerateUpgrades()
    {
        UpgradeBuilding("Airport");
        UpgradeBuilding("Warehouse");
        UpgradeBuilding("Runway");
    }
}
