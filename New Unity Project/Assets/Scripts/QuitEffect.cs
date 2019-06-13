using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitEffect : MonoBehaviour
{
	public GameObject enemy;
    private Animation enemyAni;
    private bool aniOn;

    void Start()
    {
    	aniOn = false;
    	enemyAni = enemy.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(!aniOn)
			enemyAni.Play("Idle");
    }

    IEnumerator OnMouseEnter()
    {
    	enemyAni.Play("Attack2");
    	aniOn = true;
    	yield return new WaitForSeconds(2);
    	aniOn = false;
    }
}
