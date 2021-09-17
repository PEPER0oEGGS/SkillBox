using UnityEngine;

public class TimerSound : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    private void Start()
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = _audioClip;
        GetComponent<ImageTimer>().SetAudiosourse(audio);
    }
}
