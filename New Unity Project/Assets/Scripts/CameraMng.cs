using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMng : MonoBehaviour {
    public float speed = 50;
    public float xSpeed = 2f; 
    public float ySpeed = 2f; 
    public float yMinLimit = -90f; 
    public float yMaxLimit = 90f;  


    //是否旋转镜头 鼠标右键按下时启用
    private bool isRotate;
    private float x;
    private float y;


    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void Update()
    {
        Vector3 angles = transform.localEulerAngles;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float mouse = Input.GetAxis("Mouse ScrollWheel")*50;
        transform.Translate(new Vector3(h * Mathf.Sin(angles.x * Mathf.PI/180), mouse + v * Mathf.Sin(angles.x * Mathf.PI / 180), v * Mathf.Sin(angles.x * Mathf.PI / 180)) * Time.deltaTime * speed);
        
    }

    void LateUpdate()
    {
        RotateCamera();
    }


    void RotateCamera()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRotate = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isRotate = false;
        }

        if (isRotate)
        {

            y -= Input.GetAxis("Mouse Y") * ySpeed;
            y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
            x += Input.GetAxis("Mouse X") * xSpeed;

            transform.eulerAngles = new Vector3(y, x, 0);
        }
    }



}
