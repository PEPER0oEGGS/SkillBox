using UnityEngine;

public class Lesson5 : MonoBehaviour
{
    /// <summary>
    /// Задача 1: Выведите в консоль(с помощью Debug.Log()) чётные цифры в интервале[1; 10).
    /// Задача 2: Выведите в консоль полную таблицу умножения(от 1 до 10). 
    /// Задача 3: Напишите метод с входным параметром(целое число n). Метод должен вычислять и выводить в консоль факториал входного параметра.
    /// Задача 4:
    ///         Если выписать все натуральные числа меньше 10, кратные 3 или 5, то получим 3, 5, 6 и 9. Сумма этих чисел равна 23.
    ///          Найдите сумму всех чисел меньше 1000, кратных 3 или 5.
    /// Задача 5:
    ///         Каждый следующий элемент ряда Фибоначчи получается при сложении двух предыдущих. Начиная с 1 и 2, первые 10 элементов будут:
    ///         1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
    ///         Найдите сумму всех четных элементов ряда Фибоначчи, которые не превышают четыре миллиона.
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
