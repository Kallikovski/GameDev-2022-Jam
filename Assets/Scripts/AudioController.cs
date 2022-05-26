using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioMixer Mixer;
    [SerializeField] public Slider Slider;
    [SerializeField] public PreferencesManager Preferences;

    private void Start()
    {
        Preferences.LoadPrefs();
        Slider.value = Preferences.volume;
        SetLevel();
    }
    public void SetLevel()
    {
        Mixer.SetFloat("MusicVolume", Mathf.Log10(Slider.value) * 20);
    }
    private void OnDestroy()
    {
        Preferences.volume = Slider.value;
        Preferences.SavePrefs();
    }
}
