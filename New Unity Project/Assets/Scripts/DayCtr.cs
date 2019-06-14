using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCtr : MonoBehaviour
{
    public bool isNight = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 0 && isNight)
        {
            // Debug.Log("isDay");
            isNight = false;
            GameObject.Find("gameMng").GetComponent<GuardMng>().godSleep();
        }
        else if (transform.position.y < 0 && !isNight)
        {
            // Debug.Log("isNight");
            isNight = true;
            GameObject.Find("gameMng").GetComponent<GuardMng>().godAwake();
            GameObject.Find("gameMng").GetComponent<EnemySpawner>().enemyAwake();

        }
    }
}
