using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    // public void highlight()
    // {
    //     renderer.material.color = Color.green;
    //     this.buildingOn = true;
    // }

    //鼠标放上去变绿色
    // void OnMouseEnter()
    // {
    //     Debug.Log("OnMouseEnter");
    //     if(buildingOn == false && EventSystem.current.IsPointerOverGameObject() == false)
    //     {
    //         renderer.material.color = Color.green;
    //     }
    // }

    // void OnMouseExit()
    // {
    //     Debug.Log("OnMouseExit");
    //     if(buildingOn == false && EventSystem.current.IsPointerOverGameObject() == false)
    //     {
    //         renderer.material.color = Color.white;
    //     }
    // }
}
