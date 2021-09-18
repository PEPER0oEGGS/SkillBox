using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _ExplosionTime = 3f;
    [SerializeField] private float _forceOfExp = 10f;
    [SerializeField] private float _TimeforExp = 0.1f;
    [SerializeField] private Collider cl;
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
        cl.isTrigger = boom;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Rigidbody rg))
        {
            Vector3 position = collision.gameObject.transform.position;
            rg.AddForce((position - transform.position)*(Vector3.Distance(transform.position, position) *_forceOfExp), ForceMode.Impulse);
        }
    }
}
