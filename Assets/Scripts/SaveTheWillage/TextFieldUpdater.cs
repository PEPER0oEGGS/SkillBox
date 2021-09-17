using UnityEngine;
using UnityEngine.UI;

public class TextFieldUpdater : MonoBehaviour
{
    [SerializeField] private Text[] _fields;

    public void TextUpdate(string[] values)
    {
        for (int i = 0; i < values.Length && i < _fields.Length; i++)
        {
            _fields[i].text = values[i];
        }
    }
}
