using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMashineCr : MonoBehaviour
{
    [SerializeField] private GameObject _win;
    [SerializeField] private GameObject _loze;
    [SerializeField] private GameObject _locks;
    [SerializeField] private GameObject _tools;
    [SerializeField] private GameObject _timer;

    public LocksControler GetLocksController()
    {
        return _locks.GetComponent<LocksControler>();
    }

    /// <summary>
    /// state = "Win" | "Loze" | "Game"
    /// </summary>
    /// <param name="state"></param>
    public void ScreenState(string state)
    {
        switch (state)
        {
            case ("Win"):
                _win.SetActive(true);
                _locks.SetActive(false);
                _tools.SetActive(false);
                _timer.SetActive(false);
                _loze.SetActive(false);
                break;
            case ("Loze"):
                _loze.SetActive(true);
                _locks.SetActive(false);
                _tools.SetActive(false);
                _timer.SetActive(false);
                _win.SetActive(false);
                break;
            case ("Game"):
                _loze.SetActive(false);
                _locks.SetActive(true);
                _tools.SetActive(true);
                _timer.SetActive(true);
                _win.SetActive(false);
                break;
        }
    }
}
