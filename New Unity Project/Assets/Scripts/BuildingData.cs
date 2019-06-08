using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BuildingData
{
    
    public GameObject buildingPrefab;
    public int cost;
   // public float complete = 1;
    public BuildingType type;
    public int buildingMaskUnits;
    public GameObject buildEffect;
    public int[] costRes = new int[4];

}

public enum BuildingType
{
    BuleBuilding,
    BlackBuilding,
    RedBuilding
}


