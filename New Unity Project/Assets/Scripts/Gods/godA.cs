using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godA : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> enemys = new List<GameObject>();
    public float rate = 1;
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
        timer += Time.deltaTime;
        if(enemys.Count > 0 && timer > rate)
        {
            timer = 0;
            doSomething();
        }
        // if (timer > 0)
        //     timer -= Time.deltaTime;
        // if (timer <= rate && enemys.Count > 0)
        // {
        //     doSomething();
        //     timer += rate;
        // }  
        //头部转向敌人      
        // if(enemys.Count > 0 &&enemys[0] != null)
        // {
        //     Vector3 targetPosition = enemys[0].transform.position;
        //     targetPosition.y = head
        // }
    }

    //attack
    void doSomething()
    {
        Debug.Log("attack");
        if(enemys[0] == null)
        {
            UpdateEnemys();
        }
        if(enemys.Count > 0)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, firePos.position, firePos.rotation);
            bullet.GetComponent<Bullet>().setTatget(enemys[0].transform);
        }
        else
        {
            timer = rate;
        }
        
        
    }

    void UpdateEnemys()
    {
        List<int> emptyIndex = new List<int>();
        for (int index = 0; index < enemys.Count; index++)
        {
            if (enemys[index] == null)
            {
                emptyIndex.Add(index);
            }
        }

        for (int i = 0; i < emptyIndex.Count; i++)
        {
            enemys.RemoveAt(emptyIndex[i]-i);
        }
    }
}
