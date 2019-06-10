using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private List<GameObject> gods = new List<GameObject>();
    // public GameObject selectedPrefab;
    // private new Renderer renderer;

    void Start()
    {
        // renderer = GetComponent<Renderer>();    
    }

    public void addGod(GameObject god)
    {
        gods.Add(god);
        Debug.Log(gods.Count);

    }

    // public void highlight()
    // {
    //     renderer.material.color = Color.green;
    //     this.buildingOn = true;
    // }

}
