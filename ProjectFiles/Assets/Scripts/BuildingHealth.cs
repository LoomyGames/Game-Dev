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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHealth()
    {
        if(health > 0)
        {
            health -= 20;
        }
        else if (health == 0 && !isDestroyed)
        {
            isDestroyed = true;
            GameObject exp = Instantiate(explosion, transform.position, transform.rotation);
            exp.transform.localScale = new Vector3(10, 10, 10);
            ParticleSystem after = Instantiate(afterFire, transform.position, transform.rotation);
            after.Play();
            relic.BuildingDestroyed();
            Destroy(gameObject, 3f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            DecreaseHealth();
        }
    }
}
