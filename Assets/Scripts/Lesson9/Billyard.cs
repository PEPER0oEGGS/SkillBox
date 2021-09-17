using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billyard : MonoBehaviour
{
    [SerializeField] float _force = 10;
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * _force, ForceMode.Force);
    }


}
