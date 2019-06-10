using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godA : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> enemys = new List<GameObject>();
    public float rate= 1;
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

    //rate-> attackRate
    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        if (timer <= rate && enemys.Count > 0)
        {
            doSomething();
            timer += rate;
        }        
    }

    //attack
    void doSomething()
    {
        Debug.Log("here!!!!!!");
         GameObject bullet = GameObject.Instantiate(bulletPrefab, firePos.position, firePos.rotation);
         bullet.GetComponent<Bullet>().setTatget(enemys[0].transform);
        
    }
}
