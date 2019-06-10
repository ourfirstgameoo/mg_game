using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletB : Bullet
{
    public GameObject slowDebuff;
    // Update is called once per frame


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().takeDamage(damage);
            GameObject b = GameObject.Instantiate(slowDebuff, this.transform.position,Quaternion.identity);
            Destroy(this.gameObject);
            
            

        }
    }
 
}
