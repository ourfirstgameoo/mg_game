// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class godB 
// {
//     // Start is called before the first frame update

//     void OnTriggerEnter(Collider other)
//     {
//         if(other.tag == "God")
//         {
//             other.gameObject.GetComponent<godA>().rate *= 1.2f;
//         }
//     }
//     void OnTriggerExit(Collider other)
//     {
//         if (other.tag == "God")
//         {
//             other.gameObject.GetComponent<godA>().rate /= 1.2f;
//         }
//     }
// }
