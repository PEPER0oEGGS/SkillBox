using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{

    [SerializeField] Vector3 _aim;
    [SerializeField] float _speed;
    [SerializeField] float _forse;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _aim,_speed*Time.deltaTime);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*_forse, ForceMode.VelocityChange);
        }
    }




}
