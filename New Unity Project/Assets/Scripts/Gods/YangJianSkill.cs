using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YangJianSkill : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().takeDamage(1);
        }
    }

    // void Update()
    // {
    //     if (target == null)
    //     {
    //         Die();
    //         return;
    //     }
    //     // transform.LookAt(target.position);
    //     // transform.Translate(Vector3.forward * speed * Time.deltaTime);
    // }

    // void Die()
    // {
    //     // Debug.Log("bullet die");
    //     GameObject effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
    //     Destroy(effect, 1);
    //     Destroy(this.gameObject);
    // }
}
