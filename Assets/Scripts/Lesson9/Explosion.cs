using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _ExplosionTime = 3f;
    [SerializeField] private float _forceOfExp = 10f;
    [SerializeField] private float _TimeforExp = 0.1f;
    private bool _boom=false;

        void Update()
    {
        if (!_boom)
        {
            if (_ExplosionTime > 0)
            {
                _ExplosionTime -= Time.deltaTime;
            }
            else
            {
                if(_TimeforExp > 0)
                {
                    Boom(false);
                    _TimeforExp -= Time.deltaTime;
                }
                else
                {
                    Boom(true);
                    _boom = false;
                }


            }
        }
    }

    private void Boom(bool boom)
    {
        GetComponent<Collider>().isTrigger = boom;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce((collision.gameObject.transform.position - transform.position)*(Vector3.Distance(transform.position, collision.gameObject.transform.position)*_forceOfExp), ForceMode.Impulse);
        }
    }
}
