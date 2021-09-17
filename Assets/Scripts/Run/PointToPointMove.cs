using UnityEngine;

public class PointToPointMove : MonoBehaviour
{
    [SerializeField] private Vector3[] _points;
    private GameObject[] _pointsGM;
    [SerializeField] private float _speed;
    private int _aimPoint = 0;
    private bool toLast = true;

    void Start()
    {
        transform.LookAt(_points[_aimPoint]);
        _pointsGM = new GameObject[_points.Length];
        CreatePoints();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, _points[_aimPoint]) > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, _points[_aimPoint], _speed * Time.deltaTime);
        }
        else
        {
            ChangePoint();
        }
    }
   
    private void ChangePoint()
    {
        if (toLast)
        {
            _aimPoint++;
            if (_aimPoint == _points.Length)
            {
                toLast = false;
                _aimPoint -= 2;
            }
        }
        else
        {
            _aimPoint--;
            if (_aimPoint < 0)
            {
                toLast = true;
                _aimPoint += 2;
            }
        }
        transform.LookAt(_points[_aimPoint]);
    }

    private void CreatePoints()
    {
        for (int i = 0; i < _points.Length; i++)
        {


            GameObject GM = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GM.transform.position = _points[i];
            GM.GetComponent<Collider>().enabled = false;
        }
    }

}
