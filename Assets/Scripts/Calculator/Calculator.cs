using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    [SerializeField] private InputField _firstNumber;
    [SerializeField] private InputField _secondNumber;
    [SerializeField] private InputField _answer;

    public void ClearField()
    {
        _firstNumber.text = "";
        _secondNumber.text = "";
        _answer.text = "";
    }
    public void Calc(int state)
    {
        bool isSuccess = float.TryParse(_firstNumber.text, out float value1);
        isSuccess &= float.TryParse(_secondNumber.text, out float value2);

        if (isSuccess)
        {
            switch (state)
            {
                case 1:
                    _answer.text = (value1 + value2).ToString();
                    break;
                case 2:
                    _answer.text = (value1 - value2).ToString();
                    break;
                case 3:
                    _answer.text = (value1 * value2).ToString();
                    break;
                case 4:
                    _answer.text = (value1 / value2).ToString();
                    value1 = value1 / value2;
                    Debug.LogError((value1+7).ToString());
                    break;
            }
        }
        else
        {
            _answer.text = "¬ведено не число";
        }
    }

}
