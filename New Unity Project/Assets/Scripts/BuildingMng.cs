using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingMng : MonoBehaviour
{
    public BuildingData redData;
    public BuildingData blackData;
    public BuildingData blueData;

    private BuildingData selectedData;


    public void OnRedSelected(bool isOn)
    {
        if (isOn)
        {

            this.selectedData = redData;

        }
    }

    public void OnBlueSelected(bool isOn)
    {

        if (isOn)
        {
//            Debug.Log("IM ONONONOBLUE123123123");

            this.selectedData = blueData;

        }
    }

    public void OnBlackSelected(bool isOn)
    {
        if (isOn)
        {
            this.selectedData = blackData;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {


        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            if ( Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Map")))
            {
                Debug.Log("HERE!!");

                ///-5.-25;-5,-30,-10,-25;-10,-30
                //-7.5,-27.5
                float a = hit.point.x ;
                float b = hit.point.z ;
                int[][] coordinate = new int[3][] { new int[] { 0 }, new int[] { 1, -1 }, new int[] { -1, 0, 1 } };
                int num = selectedData.buildingMaskUnits;
                MapCube[] selectPosition = new MapCube[num*num];
                bool isValid = true;
                int index = 0;
                for (int i = 0; i < num; i++)
                {
                    for(int j = 0; j < num; j++)
                    {
                        RaycastHit checkhit;
                        if (Physics.Raycast(new Vector3(a + coordinate[num-1][i]*(num-1) * 2.5f, 1, b + coordinate[num - 1][j] * (num-1) * 2.5f),
                            new Vector3(0, -1, 0), out checkhit, 10, LayerMask.GetMask("MapCube")))
                        {
                            MapCube mapCube = checkhit.collider.GetComponent<MapCube>();
                            if (mapCube == null ||mapCube.buildingOn)
                            {
                                isValid = false;
                                break;
                                //mapCube.highlight();
                            }
                            else
                            {
                                selectPosition[index] = mapCube;
                                index++;
                            }
                        }
                    }
                    if (isValid == false)
                        break;

                }
                if(isValid == true)
                {
                    Debug.Log("HERER!!!!!" + selectPosition.Length);
                    Vector3 center= new Vector3(0,0,0);
                   for( int k = 0; k < selectPosition.Length; k++)
                    {
                        selectPosition[k].highlight();
                        center += selectPosition[k].transform.position;


                    }
                    Debug.Log("GREEN!!!");

                    center /= (num*num);
                    Build(center + new Vector3(0,0.5f,0));
                }
                
                
                     
            }
        }
    }
    
    void Build(Vector3 position)
    {
        GameObject.Instantiate(selectedData.buildingPrefab, position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(selectedData.buildEffect, position, Quaternion.identity);
        Destroy(effect, 2.5f);
    }
}
