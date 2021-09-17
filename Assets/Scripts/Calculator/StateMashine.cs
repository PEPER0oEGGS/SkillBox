using UnityEngine;
using UnityEngine.UI;

public class StateMashine : MonoBehaviour
{
    [SerializeField] private GameObject _calculator;
    [SerializeField] private GameObject _twoNumbersComparer;
    [SerializeField] private GameObject _threeNumbersComparer;
    [SerializeField] private GameObject _quadraticEquation;
    [SerializeField] private Button _calculatorButton;
    [SerializeField] private Button _twoNumbersComparerButton;
    [SerializeField] private Button _threeNumbersComparerButton;
    [SerializeField] private Button _quadraticEquationButton;
    private GameObject _currentScreen;

   private void Start()
    {
        _currentScreen = _calculator;
        _calculator.GetComponent<Canvas>().enabled = true;
        EnableShangeButton(_currentScreen, false);
    }
    public void ChangeState(GameObject state)
    {
        if (_currentScreen != null)
        {
            _currentScreen.GetComponent<Canvas>().enabled = false;
            EnableShangeButton(_currentScreen, true);
            state.GetComponent<Canvas>().enabled = true;
            ClearFiellds(state);
            _currentScreen = state;
            EnableShangeButton(_currentScreen, false);
        }
    }
    private void EnableShangeButton (GameObject state, bool Interact)
    {
        if (state == _calculator)
        {
            _calculatorButton.interactable = Interact;
        }
        if (state == _twoNumbersComparer)
        {
            _twoNumbersComparerButton.interactable = Interact;
        }
        if (state == _threeNumbersComparer)
        {
            _threeNumbersComparerButton.interactable = Interact;
        }
        if (state == _quadraticEquation)
        {
            _quadraticEquationButton.interactable = Interact;
        }
    }
    private void ClearFiellds(GameObject state)
    {
        if (state.TryGetComponent<Calculator>(out Calculator obj_1)) 
        {
            obj_1.ClearField(); 
        }
        if (state.TryGetComponent<ComparerTwo>(out ComparerTwo obj_2))
        {
            obj_2.ClearField();
        }
        if (state.TryGetComponent<ComparerThree>(out ComparerThree obj_3))
        {
            obj_3.ClearField();
        }
        if (state.TryGetComponent<QuadraticEquation>(out QuadraticEquation obj_4))
        {
            obj_4.ClearField();
        }

    }
}
