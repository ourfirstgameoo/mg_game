using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeiGong : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> enemys = new List<GameObject>();
    public float rate = 1;
    private float timer = 0;
    // public Transform firePos;
    private Animation ani;
    public GameObject god;
    public GameObject effect;

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

    void Start()
    {
        ani = this.GetComponent<Animation>();
        ani["Attack2"].speed = 2;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > rate)
        {
            timer = 0;
            doSomething();
        }
        // if(enemys.Count > 0 && timer > rate)
        // {
        //     timer = 0;
        //     doSomething();
        // }
        // if(enemys.Count == 0)
        // {
        //     ani.Play("Idle");
        // }
        // if (timer > 0)
        //     timer -= Time.deltaTime;
        // if (timer <= rate && enemys.Count > 0)
        // {
        //     doSomething();
        //     timer += rate;
        // }  
        // 头部转向敌人      
        if(enemys.Count > 0 && enemys[0] != null)
        {
            Vector3 targetPosition = enemys[0].transform.position;
            targetPosition.y = god.transform.position.y;
            god.transform.LookAt(targetPosition);
        }
    }

    //attack
    void doSomething()
    {
        // if(enemys[0] == null)
        // {
        //     UpdateEnemys();
        // }
        // if(enemys.Count > 0)
        // {
        //     if(enemys.Count == 0)
        //         UpdateEnemys();
            // Debug.Log(ani["Attack2"].speed);
            ani.Play("Attack2");
            GameObject e = GameObject.Instantiate(effect, transform.position, transform.rotation);
            // Quaternion rotation = enemys[0].transform.rotation;
            // rotation.x += 1;
            // GameObject effect = GameObject.Instantiate(speedDecrease, enemys[0].transform.position, rotation);
            // Destroy(effect, 5);
        // }
        // else
        // {
        //     timer = rate;
        // }
        
        
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
