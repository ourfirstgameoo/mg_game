using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyMng[] enemys;

    private float waveRate = 1.5f;
    public int[][,] waveCtr = new int[5][,];
    
    public Transform[] startPoint = new Transform[4];
    private int day = 0;

    // Start is called before the first frame update
    void Start()
    {
        waveCtr[0] = new int[3, 6] { { 3, 1, 0, 0, 0, 0 }, { 4, 2, 0, 0, 0, 0 } , { 5, 3, 1, 0, 0, 0 } };
        waveCtr[1] = new int[3, 6] { { 5, 4, 2, 0, 0, 0 }, { 6, 4, 3, 0, 0, 0 }, { 7, 5, 4, 1, 0, 0 } };
        waveCtr[2] = new int[3, 6] { { 7, 5, 3, 2, 0, 0 }, { 7, 6, 5, 2, 0, 0 }, { 8, 6, 5, 3, 1, 0 } };
        waveCtr[3] = new int[3, 6] { { 8, 5, 3, 2, 2, 0 }, { 8, 5, 5, 4, 2, 0 }, { 8, 6, 5, 4, 2, 1 } };
        waveCtr[4] = new int[3, 6] { { 8, 8, 4, 5, 3, 3 }, { 8, 10, 6, 5, 4, 4 }, { 8, 10, 8, 7, 6, 5 } };
    }


    public void enemyAwake()
    {
        StartCoroutine(SpawnEnemy());
        day++;
    }

    IEnumerator SpawnEnemy()
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                for(int k = 0; k < waveCtr[day][i,j]; k++)
                {
                    for(int l = 0; l < 4; l++)
                    {
                        GameObject.Instantiate(enemys[j].enemy[l], startPoint[l].position, Quaternion.identity);
                    }
                    yield return new WaitForSeconds(waveRate);
                }
            }
            yield return new WaitForSeconds(waveRate);

        }
        /*
        foreach(EnemyMng wave in waves)
        {
            for(int i = 0; i < wave.count; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                  //  GameObject.Instantiate(wave.enemy[j], startPoint[j].position, Quaternion.identity);
                }
                if (i != wave.count - 1)
                    yield return new WaitForSeconds(wave.rate);
                else
                    yield return new WaitForSeconds(waveRate);

            }

        }
*/
    }
}
