using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;
    private Animator anim;
    [SerializeField]
    private Camera animCam;
    private Camera mainCam;
    private CharacterController CC;
    // Start is called before the first frame update
    void Awake()
    {
        CC = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
        anim = animCam.GetComponent<Animator>();
        mainCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        if (GameObject.FindWithTag("Inventory Manager") == null)
        {
            Instantiate(gameManager);
        } else
        {
            GameObject.FindWithTag("Inventory Manager").GetComponent<InventoryManager>().FindBuildings();
            GameObject.FindWithTag("Inventory Manager").GetComponent<InventoryManager>().GenerateUpgrades();
            mainCam.enabled = false;
            CC.enabled = false;
            animCam.enabled = true;
            anim.Play("CameraHover");
            StartCoroutine(waitForAnim());
        }
    }

    IEnumerator waitForAnim()
    {
        yield return new WaitForSeconds(4);
        mainCam.enabled = true;
        CC.enabled = true;
        animCam.enabled = false;
    }

}
