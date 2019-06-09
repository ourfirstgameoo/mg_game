using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godA : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> enemys = new List<GameObject>();
    private float attackRate = 1;
    private float timer = 0;
    public GameObject bulletPrefab;
    public Transform firePos;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemys.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Remove(other.gameObject);
        }
    }
    
    void setAttackRate(float _attackRate)
    {
        this.attackRate = _attackRate;
    }

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        if (timer <= attackRate && enemys.Count > 0)
        {
            attack();
            timer += attackRate;
        }
        
        
    }

    void attack()
    {
         GameObject bullet = GameObject.Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        bullet.GetComponent<Bullet>().setTatget(enemys[0].transform);
        
    }
}
