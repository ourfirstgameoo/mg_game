using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GuardData
{
    public GameObject GuardPrefab;
    public GuardType type;
}

public enum GuardType
{
    Guard1,
    Guard2,
    Guard3
}