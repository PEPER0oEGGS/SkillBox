using UnityEngine;
using UnityEngine.UI;

public class LocksControler : MonoBehaviour
{
    [SerializeField] private LockScript[] _locks = new LockScript[5];
    [SerializeField] private Cracker _cracker;
    private bool[] _isOpen = new bool[5];
    private int[] _openPosition = new int[5];
    private int _tryCount;
   
    private void Start()
    {
        _isOpen = new bool[_locks.Length];
        _openPosition = new int[_locks.Length];
    }

    public void ResetLocks()
    {
        for (int i = 0; i < _openPosition.Length; i++)
        {
            _openPosition[i] = Random.Range(1, 11);
            _locks[i].Reset(_openPosition[i]);
            _isOpen[i] = false;
        }
        TryCount();
        _cracker.TryShow(_tryCount.ToString());
        Debug.Log(_openPosition[0] + " " + _openPosition[1] + " " + _openPosition[2] + " " + _openPosition[3] + " " + _openPosition[4]);

    }
    
    

    public void MoveLocks(Tool tool)
    {
        int[] crack = tool.tool;
        for (int i = 0; i < _locks.Length; i++)
        {
            _isOpen[i] = _locks[i].ShangePosition(crack[i]);
        }
        if (WinCheck())
        {
            _cracker.Win();
        }
        _tryCount--;
        _cracker.TryShow(_tryCount.ToString());
        if (_tryCount == 0)
        {
            _cracker.Loze();
        }
    }

    private bool WinCheck()
    {
        bool isOpen = true;
        for (int i = 0; i < _isOpen.Length; i++)
        {
            isOpen &= _isOpen[i];
        }
        return isOpen;
    }

    private void TryCount()
    {
        _tryCount = 0;
        for (int i = 0; i < _openPosition.Length; i++)
        {
            _tryCount += _openPosition[i];
        }
    }

    }

