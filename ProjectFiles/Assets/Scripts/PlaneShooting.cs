using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneShooting : MonoBehaviour
{
    [SerializeField]
    private int damage = 20;
    [SerializeField]
    ParticleSystem muzzleFlash;


    public Transform shootingPoint;
    public GameObject projectile;
    public float launchVelocity = 700f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            muzzleFlash.Play();
            GameObject ball = Instantiate(projectile, shootingPoint.transform.position, shootingPoint.transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, launchVelocity));
            Destroy(ball, 4);
        }
    }
    
}
