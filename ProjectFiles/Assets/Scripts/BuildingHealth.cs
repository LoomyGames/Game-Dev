using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
    int health = 100;
    [SerializeField]
    GameObject explosion;
    [SerializeField]
    ParticleSystem afterFire;
    bool isDestroyed = false;
    public ReleaseRelic relic;

    public void DecreaseHealth() //decrease building health
    {
        if(health > 0)
        {
            health -= 20;
        }
        else if (health == 0 && !isDestroyed)//if the building has no health
        {
            isDestroyed = true;
            GameObject exp = Instantiate(explosion, transform.position, transform.rotation);//instantiate particle systems
            exp.transform.localScale = new Vector3(10, 10, 10);
            ParticleSystem after = Instantiate(afterFire, transform.position, transform.rotation);
            after.Play();
            relic.BuildingDestroyed();
            Destroy(gameObject, 3f);//destroy the building game object
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")//if hit by the bullet
        {
            DecreaseHealth();//call the decrease health method
        }
    }
}
