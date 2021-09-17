
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    private AudioSource _audio;
    private void Start()
    {
        GameObject GO = this.gameObject;
        _audio = GO.AddComponent<AudioSource>();
        _audio.clip = (AudioClip)Resources.Load("Audio/Button");
        Button button = GO.GetComponent<Button>();
        button.onClick.AddListener(PlaySound);

    }
    private void PlaySound()
    {
        _audio.Play();
    }
}
