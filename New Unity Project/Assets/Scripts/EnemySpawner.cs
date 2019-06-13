using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyMng[] waves;
    public float waveRate = 3;   
    public Transform[] startPoint = new Transform[4];

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());     
    }

    IEnumerator SpawnEnemy()
    {
        foreach(EnemyMng wave in waves)
        {
            for(int i = 0; i < wave.count; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    GameObject.Instantiate(wave.enemy[j], startPoint[j].position, Quaternion.identity);
                }
                if (i != wave.count - 1)
                    yield return new WaitForSeconds(wave.rate);
                else
                    yield return new WaitForSeconds(waveRate);

            }
        }
    }
}
