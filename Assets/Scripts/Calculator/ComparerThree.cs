using System;
using UnityEngine;
using UnityEngine.UI;

public class ComparerThree : MonoBehaviour
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
    public void Calc( )
    {
        float[] _inputValue = new float[3];
        bool isSuccess = float.TryParse(_firstNumber.text, out _inputValue[0]);
        isSuccess &= float.TryParse(_secondNumber.text, out _inputValue[1]);
        isSuccess &= float.TryParse(_thirdNumber.text, out _inputValue[2]);
        if (isSuccess)
        {
            Array.Sort(_inputValue);
            if (_inputValue[0] != _inputValue[2])
            {
                _answer.text = _inputValue[2].ToString() + " " + _inputValue[1].ToString();
            }
            else
            {
                _answer.text = "Равны";
            }
        }
        else
        {
            _answer.text = "Введено не число";
        }

    }
}
    

