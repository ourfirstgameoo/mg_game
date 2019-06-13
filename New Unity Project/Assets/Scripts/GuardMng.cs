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

    public List<GameObject> totalgods = new List<GameObject>();


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
                if(building.gods.Count == 0)
                {
                    Vector3 pos = building.transform.position;
                    pos.y += 5;
                    // building.transform.position.y += 20;
                    GameObject obj  = GameObject.Instantiate(guardData.GuardPrefab, pos, Quaternion.identity);

                    if (building == null){
                        Debug.Log("building is none");
                        return;
                    }
                    building.addGod(guardData.GuardPrefab);
                    totalgods.Add(obj);
                }
            }
        }
    }

    public void godAwake()
    {
        for(int i = 0; i < totalgods.Count; i++)
        {
            totalgods[i].SetActive(true);
        }  
    }

    public void godSleep()
    {
        for (int i = 0; i < totalgods.Count; i++)
        {
            totalgods[i].SetActive(true);
        }
    }
}
