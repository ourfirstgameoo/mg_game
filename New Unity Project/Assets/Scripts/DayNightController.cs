using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed = 10;
    public GameObject pointer;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.left * rotateSpeed * Time.deltaTime, Space.Self);
        pointer.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime, Space.Self);

    }
}
