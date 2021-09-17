using UnityEngine;

[CreateAssetMenu(fileName = "New Tool", menuName = "Creaker", order = 51)]
public class Tool : ScriptableObject
{

    [SerializeField] private int[] _toolBalanse = new int[5];
    public int[] tool
    {
        get
        {
            return _toolBalanse;
        }
    }
}
