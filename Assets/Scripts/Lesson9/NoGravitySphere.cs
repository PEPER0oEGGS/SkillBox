using UnityEngine;

public class NoGravitySphere : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rg))
        {
            rg.useGravity = false;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Rigidbody rg))
        {
            rg.useGravity = true;
        }
    }
}
