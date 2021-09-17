using UnityEngine;

public class EstafeteRunerScriptMod2 : MonoBehaviour
{
    [SerializeField] private GameObject _nextMan;
    [SerializeField] private RunnerAnomator _animatorNM;
    [SerializeField] private EstafeteRunerScriptMod2 _scriptNM;
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _minDistanse = 5;
    [SerializeField] private bool _isRun = false;
    [SerializeField] private RunnerAnomator _animator;

   private void Start()
    {
        transform.LookAt(_nextMan.transform.position);
        if (!_isRun)
        {
            _animator.StickLose();
        }
    }

    private void Update()
    {
        if (_isRun)
        {
            transform.position = Vector3.MoveTowards(transform.position, _nextMan.transform.position, _speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _nextMan.transform.position) < _minDistanse)
            {
                _animator.StickLose();
                _animator.IsRun(false);
                IsRun(false);
                _animatorNM.IsRun(true);
                _animatorNM.StickGet();
                _scriptNM.IsRun(true);
                _scriptNM.LockAtLeader();
            }
        }
    }

    public void IsRun(bool isRun)
    {
        _isRun = isRun;
    }

    public void LockAtLeader()
        {
            transform.LookAt(_nextMan.transform);
        }
}
