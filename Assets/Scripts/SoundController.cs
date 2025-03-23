using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundsSlider;
    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float savedSoundsVolume = PlayerPrefs.GetFloat("SoundsVolume", 1f);

        SetSliderMusicVolume(savedMusicVolume);
        SetMusicVolume(savedMusicVolume);

        SetSliderSoundsVolume(savedSoundsVolume);
        SetSoundsVolume(savedSoundsVolume);
    }

    public void OnMusicVolumeChanged(float volume)
    {
        SetMusicVolume(volume);

        SaveMusicVolume(volume);
    }

    public void OnSoundsVolumeChanged(float volume)
    {
        SetSoundsVolume(volume);

        SaveSoundsVolume(volume);
    }

    private void SetSliderMusicVolume(float volume)
    {
        musicSlider.value = volume;
    }

    private void SetMusicVolume(float volume)
    {
        float volumeInDb = Mathf.Log10(volume) * 20;

        if (volume <= 0)
        {
            volumeInDb = -80f;
        }

        audioMixer.SetFloat("MusicVolume", volumeInDb);
    }

    private void SaveMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);

        PlayerPrefs.Save();
    }

    private void SetSliderSoundsVolume(float volume)
    {
        soundsSlider.value = volume;
    }

    private void SetSoundsVolume(float volume)
    {
        float volumeInDb = Mathf.Log10(volume) * 20;

        if (volume <= 0)
        {
            volumeInDb = -80f;
        }

        audioMixer.SetFloat("SoundsVolume", volumeInDb);
    }

    private void SaveSoundsVolume(float volume)
    {
        PlayerPrefs.SetFloat("SoundsVolume", volume);

        PlayerPrefs.Save();
    }
}
