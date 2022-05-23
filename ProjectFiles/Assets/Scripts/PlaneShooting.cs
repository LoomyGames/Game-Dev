using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneShooting : MonoBehaviour
{
    [SerializeField]
    private int damage = 20;//base bullet damage
    [SerializeField]
    ParticleSystem muzzleFlash;//muzzleFlash particle system


    public Transform shootingPoint; //starting point where bullets spawn
    public GameObject projectile; //bullet prefab
    public float launchVelocity = 700f; //bullet initial velocity

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //if the left mouse button is pressed (the plane gun fires semi-automatic)
        {
            muzzleFlash.Play(); //play the muzzle flash
            GameObject ball = Instantiate(projectile, shootingPoint.transform.position, shootingPoint.transform.rotation); //instantiate the bullet at the shooting point
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, launchVelocity)); //add force to the rigidbody, to push the bullet forward
            Destroy(ball, 4); // if the bullet does not touch anything in 4 seconds it will be automatically destroyed for optimization purposes
        }
    }
    
}
