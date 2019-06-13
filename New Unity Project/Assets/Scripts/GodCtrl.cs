using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodCtrl : MonoBehaviour
{
	public List<Building> buildings = new List<Building>();
	private float timer = 0;

    void OnTriggerEnter(Collider building)
    {
        if(building.tag == "Building")
        {
    		Debug.Log(building);
            // buildings.Add(building.gameObject);
            buildings.Add(building.GetComponentInParent<Building>());
        }
    }

    //  void OnTriggerExit(Collider other)
    // {
    //     if (other.tag == "Enemy")
    //     {
    //         enemys.Remove(other.gameObject);
    //     }
    // }

    // void Update()
    // {
    //     timer += Time.deltaTime;
    //     if(buildings.Count > 0 && timer > 5)
    //     {
    //         timer = 0;
    //         AttackReady();
    //     }
    //     // AttackReady();
    // }

    void AttackReady()
    {
    	Debug.Log("ere!!!");
    	for(int i=0; i < buildings.Count; i++)
    	{
    		if(buildings[i].gods.Count > 0)
    		{
    			Debug.Log(buildings[i].transform);
    		}
    		Debug.Log(buildings[i].transform);
    	}
    }
}
