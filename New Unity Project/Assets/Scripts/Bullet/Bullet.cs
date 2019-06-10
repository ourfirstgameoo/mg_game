using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected int damage = 1;
    protected float speed;     
    private Transform target;

    private void Start()
    {
        setSpeed(30);
    }
    public void setTatget(Transform _target)
    {
        this.target = _target;
    }

    public void setSpeed(float _speed)
    {
        this.speed = _speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("here father");

    }
}
