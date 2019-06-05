using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCube : MonoBehaviour
{
    public GameObject selectedPrefab;
    [HideInInspector]
    public bool buildingOn = false;
    private new Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();    
    }

    public void highlight()
    {
        renderer.material.color = Color.green;
        this.buildingOn = true;
    }

}
