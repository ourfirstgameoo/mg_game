using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletC : Bullet
{
    // Update is called once per frame

    private void Start() 
    {
        setSpeed(20);
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hereC");
        if (other.tag == "Enemy")
        {
            Debug.Log("here!!!!!!!!!!!!!!!!");

            other.GetComponent<Enemy>().takeDamage(damage);
            Debug.Log("here!!!!!!!!!!!!!!!!123123123123");

            Destroy(gameObject);


        }
    }
}
