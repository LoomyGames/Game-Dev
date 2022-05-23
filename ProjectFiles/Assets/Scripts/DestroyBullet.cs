using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public ParticleSystem hitParticles; //impact particles

    private void OnCollisionEnter(Collision collision) // when the bullet hits something, destroy it and instantiate sparks particles in that spot
    {
        ParticleSystem particles = Instantiate(hitParticles, transform.position, transform.rotation);
        particles.Play();
        Destroy(particles.gameObject, 0.1f);
        Destroy(gameObject, 0.1f);
    }
}
