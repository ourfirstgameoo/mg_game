using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeiGong : MonoBehaviour
{
    // Start is called before the first frame update
    private List<Enemy> enemys = new List<Enemy>();
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
            enemys.Add(other.GetComponent<Enemy>());
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Remove(other.GetComponent<Enemy>());
        }
    }

    void Start()
    {
        ani = this.GetComponent<Animation>();
        ani["Attack2"].speed = 2;
    }

    private void Update()
    {
        if(enemys.Count == 0 && attackIdletime > 1)
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

            attackIdletime = 0;
            ani.Play("Attack2");
            Quaternion rotation = skill.transform.rotation;
            // rotation.x += 180;
            // rotation.y += 180;
            // rotation.z += 180;
            Vector3 pos = enemys[0].transform.position;
            // pos.y -= 10;
            GameObject effect = GameObject.Instantiate(skill, pos, rotation);
            enemys[0].takeDamage(1);
            // Destroy(effect, 5);
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
