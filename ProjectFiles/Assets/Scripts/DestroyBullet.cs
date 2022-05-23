using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public ParticleSystem hitParticles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        ParticleSystem particles = Instantiate(hitParticles, transform.position, transform.rotation);
        particles.Play();
        Destroy(particles.gameObject, 0.1f);
        Destroy(gameObject, 0.1f);
    }
}
