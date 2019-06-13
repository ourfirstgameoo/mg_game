using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEffect : MonoBehaviour
{
	public GameObject god;
    private Animation godAni;
    private bool aniOn;

    void Start()
    {
    	aniOn = false;
    	godAni = god.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(!aniOn)
			godAni.Play("Idle");
    }

    IEnumerator OnMouseEnter()
    {
    	godAni.Play("Attack2");
    	aniOn = true;
    	yield return new WaitForSeconds(2);
    	aniOn = false;
    }
}
