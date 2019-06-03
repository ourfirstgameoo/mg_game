﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform[] positions;
    private int index = 0;
    public float speed = 10;
    public string type = "path_a";
    public int randPathNum = 2;
    void Start()
    {
        int randpath = Random.Range(0,randPathNum);
        WavePoints a = GameObject.Find(type + randpath.ToString()).GetComponent<WavePoints>();
        positions = a.positions;
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
}
