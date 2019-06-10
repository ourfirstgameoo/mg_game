using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowdebuff : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().speed /= 1.2f;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().speed *= 1.2f;
        }
    }
}
