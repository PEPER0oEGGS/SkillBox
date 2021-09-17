using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessNumder : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private InputField inputText;
    private int N = 0;

    void Start()
    {
        N = Random.Range(1, 101);
        Debug.Log("�������������: " + N); 

    }
    public void Click()
    {
        if (int.Parse(inputText.text) > N)
        {
            text.text = "����� ������ ����������";
        }
        if (int.Parse(inputText.text) < N)
        {
            text.text = "����� ������ ����������";
        }
        if (int.Parse(inputText.text) == N)
        {
            text.text = "�� �������! ������� ����.";
            Start();
        }

    }


}
