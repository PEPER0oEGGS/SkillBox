using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComparerTwo : MonoBehaviour
{
    [SerializeField] private InputField _firstNumber;
    [SerializeField] private InputField _secondNumber;
    [SerializeField] private InputField _answer;

    // Start is called before the first frame update
    public void ClearField()
    {
        _firstNumber.text = "";
        _secondNumber.text = "";
        _answer.text = "";
    }
    public void Calc( )
    {
        bool corect = true;
        bool isSuccess = float.TryParse(_firstNumber.text, out float value1);
        isSuccess &= float.TryParse(_secondNumber.text, out float value2);
        if (isSuccess)
        {
            if (value1 > value2)
            {
                _answer.text = value1.ToString();
            }
            if (value1 < value2)
            {
                _answer.text = value2.ToString();
            }
            if (value1 == value2)
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
    

