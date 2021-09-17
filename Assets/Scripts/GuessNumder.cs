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
        Debug.Log("Сгенерировано: " + N); 

    }
    public void Click()
    {
        if (int.Parse(inputText.text) > N)
        {
            text.text = "Число больше загаданого";
        }
        if (int.Parse(inputText.text) < N)
        {
            text.text = "Число меньше загаданого";
        }
        if (int.Parse(inputText.text) == N)
        {
            text.text = "Вы угадали! Рестарт игры.";
            Start();
        }

    }


}
