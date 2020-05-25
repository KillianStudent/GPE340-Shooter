using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameManager gameManager;
    public AudioMixer audioMixer;

    public float MusicPref;
    public float SuondEffectPref;

    private bool isFullScreen = false;

    // Settings buttons
    [SerializeField] private GameObject LowSettingsButton;
    [SerializeField] private GameObject MidSettingsButton;
    [SerializeField] private GameObject HighSettingsButton;
    [SerializeField] private GameObject Resolution640x480Button;
    [SerializeField] private GameObject Resolution1280x720Button;
    [SerializeField] private GameObject Resolution1920x1080Button;
    [SerializeField] private GameObject FullScreenToggle;
    [SerializeField] private GameObject SoundEffectVolumeSlider;
    [SerializeField] private GameObject MusicVolumeSlider;
    [SerializeField] private GameObject WeaponSprite;

    public void Start()
    {
        LowSettingsButton.GetComponent<Button>().onClick.AddListener(changeQualityLow); // quality settings assignings
        MidSettingsButton.GetComponent<Button>().onClick.AddListener(changeQualityMid);
        HighSettingsButton.GetComponent<Button>().onClick.AddListener(changeQualityHigh);

        Resolution640x480Button.GetComponent<Button>().onClick.AddListener(changeresolution640x480);
        Resolution1280x720Button.GetComponent<Button>().onClick.AddListener(changeresolutionx1280x720);
        Resolution1920x1080Button.GetComponent<Button>().onClick.AddListener(changeresolution1920x1080);

        audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolumePreference"));  // gets the music volume and sets the volume on the slider
        MusicVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolumePreference");
        audioMixer.SetFloat("SoundEffectVolume", PlayerPrefs.GetFloat("SoundEffectVolumePreference"));  // gets the sound effect volume and sets the volume on the slider
        SoundEffectVolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SoundEffectVolumePreference");
    }

    public void changeVisibility(bool active)
    {
        LowSettingsButton.SetActive(active);
        MidSettingsButton.SetActive(active);
        HighSettingsButton.SetActive(active);
        Resolution640x480Button.SetActive(active);
        Resolution1280x720Button.SetActive(active);
        Resolution1920x1080Button.SetActive(active);
        FullScreenToggle.SetActive(active);
        SoundEffectVolumeSlider.SetActive(active);
        MusicVolumeSlider.SetActive(active);
        WeaponSprite.SetActive(active);
    }

    public void changeQualityLow()
    {
        QualitySettings.SetQualityLevel(3);
    }

    public void changeQualityMid()
    {
        QualitySettings.SetQualityLevel(6);
    }

    public void changeQualityHigh()
    {
        QualitySettings.SetQualityLevel(9);
    }

    public void changeresolution640x480() // screen resolution sizes
    {
        Screen.SetResolution(640, 480, isFullScreen);
    }

    public void changeresolutionx1280x720()
    {
        Screen.SetResolution(1280, 720, isFullScreen);
    }

    public void changeresolution1920x1080()
    {
        Screen.SetResolution(1920, 1080, isFullScreen);
    }

    public void SetMusicVolume(float musicVolume)   // music volume slider
    {
        audioMixer.SetFloat("MusicVolume", musicVolume);    // sets the slider on the audiomixer of MusicVolume
        PlayerPrefs.SetFloat("MusicVolumePreference", musicVolume);
    }

    public void SetSoundEffectVolume(float soundEffectVolume)
    {
        audioMixer.SetFloat("SoundEffectVolume", soundEffectVolume);    // sets the slider on the audiomixer of SoundEffectVolume
        PlayerPrefs.SetFloat("SoundEffectVolumePreference", soundEffectVolume);
    }
}