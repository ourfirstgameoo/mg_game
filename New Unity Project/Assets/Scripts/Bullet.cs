using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;
    public float speed = 50;
    private Transform target;
    
    public void setTatget(Transform _target)
    {
        this.target = _target;
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
