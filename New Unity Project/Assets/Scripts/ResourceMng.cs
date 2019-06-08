using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ResourceMng : MonoBehaviour
{
    private int[] resource = new int[4] { 100, 100,100, 100 };

    public Text[] ResText = new Text[4];

    public void updateRes(int[] cost)
    {
        for(int i = 0; i < 4; i++)
        {
            resource[i] -= cost[i];
            ResText[i].text = "$" + resource[i];
        }
    }
    
    public bool checkRes(int[] cost)
    {
        for(int i= 0; i < 4; i++)
        {
            if (resource[i] < cost[i])
                return false;
        }

        return true;

    }    
    


}
