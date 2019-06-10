using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletA : Bullet
{
    public GameObject damageDebuff;
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().takeDamage(damage);
            GameObject b = GameObject.Instantiate(damageDebuff, this.transform);


            Destroy(this.gameObject);

        }
    }
}
