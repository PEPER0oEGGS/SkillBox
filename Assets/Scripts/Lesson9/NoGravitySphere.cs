using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoGravitySphere : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            other.GetComponent<Rigidbody>().useGravity = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            other.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
