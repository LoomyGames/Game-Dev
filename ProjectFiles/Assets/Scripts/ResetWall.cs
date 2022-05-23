using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWall : MonoBehaviour
{
    public GameObject resetLocation;
    private CharacterController CC;

    private void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other) // if the player falls out of the map (in the lobby) reset its position back to the surface 
    {
        if (other.CompareTag("WallReset"))
        {
            CC.enabled = false; //disable the controller for a bit
            Debug.Log("Reset player location");
            gameObject.transform.position = resetLocation.transform.position; //change the location
            CC.enabled = true; //re-enable the controller
        }
    }
}
