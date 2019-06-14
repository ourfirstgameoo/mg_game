using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeiGongSkill : MonoBehaviour
{
    protected int damage = 10;
    protected Transform target;

    public void setTatget(Transform _target)
    {
        this.target = _target;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().takeDamage(damage);
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
    }

    void Die()
    {
        // Debug.Log("bullet die");
        Destroy(this.gameObject);
    }
}
