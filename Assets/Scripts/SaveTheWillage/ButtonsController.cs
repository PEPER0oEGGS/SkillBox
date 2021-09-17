using UnityEngine;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private GameManager _gameManager;

    private void Update()
    {
        bool[] buttonsState = _gameManager.GetButtonsState();
        for (int i = 0; i < _buttons.Length && i < buttonsState.Length; i++)
        {
            _buttons[i].interactable = buttonsState[i]; 
        }
    }
}
