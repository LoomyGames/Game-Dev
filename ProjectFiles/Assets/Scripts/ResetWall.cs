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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WallReset"))
        {
            CC.enabled = false;
            Debug.Log("Reset player location");
            gameObject.transform.position = resetLocation.transform.position;
            CC.enabled = true;
        }
    }
}
