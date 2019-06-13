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
    		// Debug.Log("initialize a new building!!!");
            buildings.Add(building.GetComponent<Building>());
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
    		;
    	}
    }

}
