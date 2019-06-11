using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected int damage = 1;
    protected float speed;     
    protected Transform target;

    private void Start()
    {
        setSpeed(40);
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
    

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("here father");
    }


}
