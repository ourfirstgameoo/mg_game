using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagedebuff : MonoBehaviour
{

    // Start is called before the first frame update


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
//            other.gameObject.GetComponent<Enemy>().health /=1.2f;
        }
    }

}


