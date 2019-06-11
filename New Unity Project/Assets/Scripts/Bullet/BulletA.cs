using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletA : Bullet
{
    // public GameObject damageDebuff;
    public GameObject explosionEffectPrefab;
    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("takeDamage");
            other.GetComponent<Enemy>().takeDamage(damage);
            Debug.Log("bullet going to die");
            Die();
        }
    }

    void Update()
    {
        if (target == null)
        {
            Die();
            return;
        }
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Die()
    {
        Debug.Log("bullet die");
        GameObject effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
        Destroy(effect, 1);
        Destroy(this.gameObject);
    }
}
