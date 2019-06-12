using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCtrl : MonoBehaviour
{
    public GameObject[] canvas = new GameObject[2];
    private GameObject nowOn;
    public bool BuildingOn = false;
    public bool GodOn = false;

    public void Click(int value)
    {
        if(nowOn != null)
        {
            nowOn.SetActive(false);
            if(nowOn == canvas[value])
            {
                nowOn = null;
            }
            else
            {
                nowOn = canvas[value];
                nowOn.SetActive(true);
            }
        }
        else
        {
            nowOn = canvas[value];
            nowOn.SetActive(true);
        }
        if(value == 0)
        {
            BuildingOn = true;
            GodOn = false;
        }
        else
        {
            BuildingOn = false;
            GodOn = true;
        }
    }
}
