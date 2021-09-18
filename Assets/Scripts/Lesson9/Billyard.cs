using UnityEngine;


public class Billyard : MonoBehaviour
{
    [SerializeField] private Rigidbody rg;
    [SerializeField] float _force = 10;
    
    void Start()
    {
        rg.AddForce(Vector3.right * _force, ForceMode.Force);
    }
}
