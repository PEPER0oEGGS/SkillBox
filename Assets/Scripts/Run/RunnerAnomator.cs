using UnityEngine;

public class RunnerAnomator : MonoBehaviour
{
    [SerializeField] private GameObject ArmL;
    [SerializeField] private GameObject ArmR;
    [SerializeField] private GameObject LegL;
    [SerializeField] private GameObject LegR;
    [SerializeField] private GameObject Stick;
    [SerializeField] private bool _isRun = false;
    [SerializeField] private float _maxAngle;
    [SerializeField] private float[] _rotators;
    [SerializeField] private float _rotatorMin = 70f;
    [SerializeField] private float _rotatorMax = 120f;
    [SerializeField] private bool _directionControllerArm = false;
    [SerializeField] private bool _directionControllerLeg = false;
    private float _rotatorArm;
    private float _rotatorLeg;
    private float _angleArm;
    private float _angleLeg;

    private void Start()
    {
        if (_directionControllerArm)
        {
            _rotatorArm = -Random.RandomRange(_rotatorMin, _rotatorMax);
        }
        else
        {
            _rotatorArm = Random.RandomRange(_rotatorMin, _rotatorMax);
        }
        if (_directionControllerLeg)
        {
            _rotatorLeg = -Random.RandomRange(_rotatorMin, _rotatorMax);
        }
        else
        {
            _rotatorLeg = Random.RandomRange(_rotatorMin, _rotatorMax);
        }
    }

    private void Update()
    {
        if (_isRun)
        {
            ArmL.transform.Rotate(-_rotatorArm * Time.deltaTime, 0, 0);
            ArmR.transform.Rotate(_rotatorArm * Time.deltaTime, 0, 0);
            LegL.transform.Rotate(-_rotatorLeg * Time.deltaTime, 0, 0);
            LegR.transform.Rotate(_rotatorLeg * Time.deltaTime, 0, 0);
            _angleArm += _rotatorArm * Time.deltaTime;
            _angleLeg += _rotatorLeg * Time.deltaTime;
            if (-_maxAngle >= _angleArm && _directionControllerArm)
            {
                _rotatorArm = -Random.RandomRange(70, 100) * _rotatorArm / Mathf.Abs(_rotatorArm);
                _directionControllerArm = false;
            }
            if (!_directionControllerArm && _angleArm >= _maxAngle)
            {
                _rotatorArm = -Random.RandomRange(70, 100) * _rotatorArm / Mathf.Abs(_rotatorArm);
                _directionControllerArm = true;
            }
            if (-_maxAngle >= _angleLeg && _directionControllerLeg)
            {
                _rotatorLeg = -Random.RandomRange(70, 100) * _rotatorLeg / Mathf.Abs(_rotatorLeg);
                _directionControllerLeg = false;
            }
            if (!_directionControllerLeg && _angleLeg >= _maxAngle)
            {
                _rotatorLeg = -Random.RandomRange(70, 100) * _rotatorLeg / Mathf.Abs(_rotatorLeg);
                _directionControllerLeg = true;
            }
        }
    }

    public void IsRun(bool isRun)
    {
        Quaternion q = new Quaternion();
        q.Set(0, 0, 0, 0);
        ArmL.transform.rotation = q;
        ArmR.transform.rotation = q;
        LegL.transform.rotation = q;
        LegR.transform.rotation = q;
        _isRun = isRun;
    }

    public void StickGet()
    {
        Stick.gameObject.active = true;
    }

    public void StickLose()
    {
        Stick.gameObject.active = false;
    }
}
