using UnityEngine;

public class PinballShooter : MonoBehaviour
{
    [SerializeField] private float _force = 1000;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private SpringJoint _sj;
    [SerializeField] private float _timerWait = 1000;
    [SerializeField] private float _timerShoot = 1000;
    private float _timerWaitCounter;
    private bool _isWait = true;
    void Start()
    {
        _timerWaitCounter = _timerWait;
        _sj.tolerance = 2;
    }
    void Update()
    {
        _timerWaitCounter--;
        if (_isWait)
        {
            _rb.AddRelativeForce(new Vector3(0, 0, -1) * _force * Time.deltaTime, ForceMode.Force);
            if (_timerWaitCounter == 0)
            {
                _timerWaitCounter = _timerWait;
                _sj.tolerance = 0f; 
                _isWait = false;
            }
        }
        else
        {
            if (_timerWaitCounter == 0)
            {
                _timerWaitCounter = _timerShoot;
                _sj.tolerance = 2f;
                _isWait = true;
            }
        }
    }
}
