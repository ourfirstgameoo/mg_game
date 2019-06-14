using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JianSu : MonoBehaviour
{
    private List<GameObject> enemys = new List<GameObject>();
    public float rate = 1;
    private float timer = 0;
    private Animation ani;
    public GameObject god;
    public GameObject skill;
    private float attackIdletime = 0;

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
        ani["Attack1"].speed = 2;
    }

    private void Update()
    {
    	if(enemys.Count == 0)
        {
            ani.Play("Idle");
        }

        timer += Time.deltaTime;
        attackIdletime += Time.deltaTime;
        if(enemys.Count > 0 && timer > rate)
        {
            timer = 0;
            doSomething();
        }
        
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
        if(enemys[0] == null)
        {
            UpdateEnemys();
        }
        if(enemys.Count > 0)
        {
            if(enemys.Count == 0)
                UpdateEnemys();

            ani.Play("Attack1");
            Vector3 pos = enemys[0].transform.position;
            GameObject effect = GameObject.Instantiate(skill, pos, skill.transform.rotation);
            Destroy(effect, 3);
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
