using UnityEngine;
using UnityEngine.UI;

public class LockScript : MonoBehaviour
{
    private int _openPosition;

    public void Reset(int openPozition)
    {
        GetComponent<Slider>().value = 0;
        GetComponent<Slider>().image.color = Color.white;
        _openPosition = openPozition;
    }
    public bool ShangePosition(int a)
    {
        GetComponent<Slider>().value += a;
        if (((int)GetComponent<Slider>().value) == _openPosition )
        {
            GetComponent<Slider>().image.color = Color.green;
            return true;
        }
        else
        {
            GetComponent<Slider>().image.color = Color.white;
            return false;
        }
    }
}
