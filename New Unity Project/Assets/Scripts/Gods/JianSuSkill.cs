using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JianSuSkill : MonoBehaviour
{
    private List<Enemy> enemys = new List<Enemy>();
    private float timer = 0;
    private double rate = 0.5;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().speed /= 2f;
            enemys.Add(other.gameObject.GetComponent<Enemy>());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().speed *= 2f;
            enemys.Remove(other.gameObject.GetComponent<Enemy>());
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(enemys.Count > 0 && timer > rate)
        {
            timer = 0;
            for(int i=0; i < enemys.Count; i++)
                enemys[i].takeDamage((float)rate);
        }
    }
}
