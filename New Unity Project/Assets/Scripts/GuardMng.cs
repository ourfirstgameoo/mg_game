using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GuardMng : MonoBehaviour
{
    public GuardData Guard1st;
    public GuardData Guard2nd;
    public GuardData Guard3rd;

    private GuardData guardData;
    public ButtonCtrl buttonCtrl;

    public List<GameObject> totalDayGods = new List<GameObject>();
    public List<GameObject> totalNightGods = new List<GameObject>();

    public void OnGuard1Selected(bool isOn)
    {
        if (isOn)
        {
            this.guardData = Guard1st;
        }
    }

    public void OnGuard2Selected(bool isOn)
    {
        if (isOn)
        {
            this.guardData = Guard2nd;
        }
    }

    public void OnGuard3Selected(bool isOn)
    {
        if (isOn)
        {
            this.guardData = Guard3rd;
        }
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false && buttonCtrl.GodOn)
        {
            if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Building")))
            {
                Building building = hit.collider.GetComponentInParent<Building>();
                if(building.god == null)
                {
                    if(guardData == Guard1st){
                        building.god1Day.SetActive(true);
                        totalDayGods.Add(building.god1Day);
                        totalNightGods.Add(building.god1Night);
                    }
                    else if(guardData == Guard2nd){
                        building.god2Day.SetActive(true);
                        totalDayGods.Add(building.god2Day);
                        totalNightGods.Add(building.god2Night);
                    }
                    else if(guardData == Guard3rd){
                        building.god3Day.SetActive(true);
                        totalDayGods.Add(building.god3Day);
                        totalNightGods.Add(building.god3Night);
                    }
                    building.god = guardData.GuardPrefab;
                    // building.addGod(guardData.GuardPrefab);
                }
            }
        }
    }

    public void godAwake()
    {
        for(int i = 0; i < totalDayGods.Count; i++)
        {
            totalNightGods[i].SetActive(true);
            totalDayGods[i].SetActive(false);
        }  
    }

    public void godSleep()
    {
        for (int i = 0; i < totalDayGods.Count; i++)
        {
            totalNightGods[i].SetActive(false);
            totalDayGods[i].SetActive(true);
        }
    }
}
