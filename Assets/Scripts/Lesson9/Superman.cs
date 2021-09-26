using UnityEngine;

public class Superman : MonoBehaviour
{

    [SerializeField] Vector3 _aim;
    [SerializeField] float _speed;
    [SerializeField] float _forse;
    [SerializeField] Rigidbody _rg;


    private void Start()
    {
        //_rg.velocity = new Vector3(10, 0, 0);
        _rg.AddForce(new Vector3(10, 0, 0) * _speed, ForceMode.VelocityChange);
    }

    void Update()
    {
      // _rg.AddForce(new Vector3(1, 0, 0)* _speed,ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Rigidbody rg))
        {
            rg.AddForce(transform.forward*_forse, ForceMode.VelocityChange);
        }
    }

}
