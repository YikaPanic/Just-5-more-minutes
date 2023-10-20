using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();

        if (audioSource)
        {
            volumeSlider.value = audioSource.volume;
        }
        
        volumeSlider.onValueChanged.AddListener(AdjustVolume);
    }

    public void AdjustVolume(float volume)
    {
        if (audioSource)
        {
            audioSource.volume = volume;
        }
    }
}
