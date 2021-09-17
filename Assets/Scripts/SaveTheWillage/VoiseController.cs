using UnityEngine;

public class VoiseController : MonoBehaviour
{
    private bool setMute = true;
    public void SetMute()
    {
        setMute = !setMute;
        GetComponent<AudioListener>().enabled = setMute;
    }

}
