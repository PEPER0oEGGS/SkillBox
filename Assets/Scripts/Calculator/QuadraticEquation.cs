using UnityEngine;
using UnityEngine.UI;

public class QuadraticEquation : MonoBehaviour
{
    [SerializeField] private InputField _firstNumber;
    [SerializeField] private InputField _secondNumber;
    [SerializeField] private InputField _thirdNumber;
    [SerializeField] private InputField _answer;

    public void ClearField()
    {
        _firstNumber.text = "";
        _secondNumber.text = "";
        _thirdNumber.text = "";
        _answer.text = "";
    }
    public void Calc()
    {
        bool isSuccess = float.TryParse(_firstNumber.text, out float a);
        isSuccess &= float.TryParse(_secondNumber.text, out float b);
        isSuccess &= float.TryParse(_thirdNumber.text, out float c);
       
        if (isSuccess)
        {
            c = b * b - 4 * a * c; // D
            if (c < 0)
            {
                _answer.text = "Корней Нет =(";
            }
            else if (c == 0)
            {
                _answer.text = "Корнь = " + (-b / (2 * a)).ToString();
            }
            else
            {
                _answer.text = "Корни = " + ((-b - c) / (2 * a)).ToString() + " " + ((-b + c) / (2 * a)).ToString();
            }
        }
        else
        {
            _answer.text = "Введено не число";
        }
    }
}
    

