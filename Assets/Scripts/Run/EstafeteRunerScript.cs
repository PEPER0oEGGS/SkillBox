using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstafeteRunerScript : MonoBehaviour
{
    [SerializeField] private GameObject _startPoint;
    [SerializeField] private GameObject _finishPoint;
    [SerializeField] private float _speed = 2;
    [SerializeField] private bool _isRun = false;
    [SerializeField] private RunnerAnomator _animator;

    private void Start()
    {
        transform.LookAt(_finishPoint.transform.position);
        if (!_isRun)
        {
            _animator.StickLose();
        }
    }

    private void Update()
    {
        if (_isRun)
        {
            transform.position = Vector3.MoveTowards(transform.position, _finishPoint.transform.position, _speed * Time.deltaTime);
        }
    }

    public GameObject[] GetPoints()
    {
        return new GameObject[] { _startPoint, _finishPoint};
    }

    public void SetPoints(GameObject[] points)
    {
        _startPoint = points[0];
        _finishPoint = points[1];
        transform.LookAt(_finishPoint.transform.position);
    }

    public void IsRun(bool isRun)
    {
        _isRun = isRun;
    }
    public void StartRun()
    {
        IsRun(true);
        _animator.IsRun(true);
        _animator.StickGet();
    }
    public void StopRun(GameObject[] points)
    {
        IsRun(false);
        _animator.IsRun(false);
        SetPoints(points);
    }
    public void StickLose()
    {
        _animator.StickLose();
    }
}
