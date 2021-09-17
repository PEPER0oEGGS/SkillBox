using UnityEngine;

public class Lesson5 : MonoBehaviour
{
    /// <summary>
    /// ������ 1: �������� � �������(� ������� Debug.Log()) ������ ����� � ���������[1; 10).
    /// ������ 2: �������� � ������� ������ ������� ���������(�� 1 �� 10). 
    /// ������ 3: �������� ����� � ������� ����������(����� ����� n). ����� ������ ��������� � �������� � ������� ��������� �������� ���������.
    /// ������ 4:
    ///         ���� �������� ��� ����������� ����� ������ 10, ������� 3 ��� 5, �� ������� 3, 5, 6 � 9. ����� ���� ����� ����� 23.
    ///          ������� ����� ���� ����� ������ 1000, ������� 3 ��� 5.
    /// ������ 5:
    ///         ������ ��������� ������� ���� ��������� ���������� ��� �������� ���� ����������. ������� � 1 � 2, ������ 10 ��������� �����:
    ///         1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
    ///         ������� ����� ���� ������ ��������� ���� ���������, ������� �� ��������� ������ ��������.
    /// 
    /// </summary>

    private const int _maxFibonachi = 4000000;
    private void Start()
    {
       // TaskOne();
      //  TaskTwo();
        TaskThree(5);
       // TaskFour();
       // TaskFive();
    }

    private void TaskOne()
    {
        for (int i = 1; i < 10; i++)
        {
            if (i % 2 == 0)
            {
                Debug.Log(i);
            }
        }
    }
    private void TaskTwo()
    {
        for (int i = 1; i <= 10; i++)
        {
            for (int j = 0; j <= 10; j++)
            {
                Debug.Log(i + " * " + j + " = " + (i * j));
            }
        }
    }
    private void TaskThree(int n)
    {
        long fact = n;
        for (n--; n > 0;)
        {
            fact *= n;
            n--;
        }
        Debug.Log(fact);
    }
    private void TaskFour()
    {
        int summ = 0;
        for (int i = 0; i < 1000; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                summ = summ + i;
            }
        }
        Debug.Log(summ);
    }
    private void TaskFive()
    {
        int a = 1;
        int b = 2;
        int summ = b;
        Debug.Log(NextFibonachi(a, b, summ));
    }
    private int NextFibonachi(int a, int b, int summ)
    {
        a = a + b;

        if (a < _maxFibonachi)
        {
            if (a % 2 == 0)
            {
                summ = summ + a;
            }
            summ = NextFibonachi(b, a, summ);
        }
        return (summ);
    }
}
