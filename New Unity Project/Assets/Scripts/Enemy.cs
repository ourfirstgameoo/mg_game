using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform[] positions;
    private int index = 0;
    public float speed = 10;
    public string type = "path_a";
    public int randPathNum = 2;
    private int totalHp;
    public int hp = 2;
    public GameObject explosionEffect;
    public Slider hpSlider;

    void Start()
    {
        int randpath = Random.Range(0,randPathNum);
        WavePoints a = GameObject.Find(type + randpath.ToString()).GetComponent<WavePoints>();
        positions = a.positions;
        totalHp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (index > positions.Length - 1) return;
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
        if(Vector3.Distance(positions[index].position, transform.position) < 0.2f)
        {
            index++;
        }
    }

    public void takeDamage(int damage)
    {
        // Debug.Log(hp);
        if(hp <= 0) return;
        hp -= damage;
        // Debug.Log(hp);
        hpSlider.value = (float)hp / totalHp;
        if(hp <= 0)
        {
            // Debug.Log("die");
            Die();
        }
        // Debug.Log(hp);
    }
    
    void changeSpeed(float speed)
    {

    }

    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(effect, 1);
        Destroy(this.gameObject);
    }
}
