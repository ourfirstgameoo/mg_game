using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform[] positions;
    private int index = 0;
    public float speed = 10;
    public string type = "path_a";
    public int randPathNum = 2;
    private float totalHp;
    public float hp = 5;
    // public GameObject explosionEffect;
    public Slider hpSlider;
    private Animation ani;
    public GameObject enemy;

    void Start()
    {
        int randpath = Random.Range(0,randPathNum);
        WavePoints a = GameObject.Find(type + randpath.ToString()).GetComponent<WavePoints>();
        positions = a.positions;
        totalHp = hp;
        ani = this.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(transform.position);
        // Debug.Log(positions[index].position);
        Move();
    }

    void Move()
    {
        if (index > positions.Length - 1) return;
        transform.LookAt(positions[index]);
        transform.Translate(0,0, Time.deltaTime * speed);
        // enemy.transform.LookAt(positions[index].position);
        // Vector3 targetPosition = positions[index].position;
        // targetPosition.y = enemy.transform.position.y;
        // enemy.transform.LookAt(targetPosition);

        ani.Play("Run");
        if(Vector3.Distance(positions[index].position, transform.position) < 0.2f)
        {
            index++;
        // enemy.transform.LookAt(positions[index].position);
            // Debug.Log(positions[index].position);
            // Vector3 targetPosition = positions[index].position;
            // targetPosition.y = enemy.transform.position.y;
            // enemy.transform.LookAt(targetPosition);
        }
    }

    public void takeDamage(float damage)
    {
        if(hp <= 0) return;
        hp -= damage;
        hpSlider.value = hp / totalHp;
        if(hp <= 0)
        {
            Die();
        }
    }
    
    void changeSpeed(float speed)
    {

    }

    void Die()
    {
        // GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
        // Destroy(effect, 1);
        Destroy(this.gameObject);
    }
}
