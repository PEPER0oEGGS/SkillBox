using UnityEngine;

public class TransferZone : MonoBehaviour
{
    private int _runnerCount = 0;
    private EstafeteRunerScript Runner1;
    private EstafeteRunerScript Runner2;
    
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<EstafeteRunerScript>(out EstafeteRunerScript script))
        {
            if (Runner1 == null)
            {
                Runner1 = script;
                _runnerCount++;
            }
            else
            {
                if (Runner1 != script)
                {
                    Runner2 = script;
                    _runnerCount++;
                }
            }
        }
        if (_runnerCount == 2)
        {
            Runner2.StickLose();
            Runner1.StartRun();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<EstafeteRunerScript>(out EstafeteRunerScript script))
        {
            if (script == Runner1)
            {
                Runner2.StopRun(Runner1.GetPoints());
                Runner1 = Runner2;
                Runner2 = null;
                _runnerCount--;
            }
            if (script == Runner2)
            {
                Runner2 = null;
                _runnerCount--;
            }
        }
    }
}
