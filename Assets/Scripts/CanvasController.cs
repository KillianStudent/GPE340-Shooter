using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class CanvasController : MonoBehaviour
{
    public GameManager gameManager;
    public OptionsMenu optionsMenu;

    private Canvas canvas;
    [SerializeField] private GameObject UIHealthObject;
    [SerializeField] private GameObject UILivesObject;
    public UIHealthText healthDisplay;
    public UILivesDisplay livesDisplay;

    public Pawn pawn;

    public GameObject ResumeButton;
    public GameObject SettingsButton;
    public GameObject QuitButton;

    private bool isFullScreen = false;
    private bool settingsActive = false;

    // Settings buttons
    [SerializeField] private GameObject LowSettingsButton;
    [SerializeField] private GameObject MidSettingsButton;
    [SerializeField] private GameObject HighSettingsButton;
    [SerializeField] private GameObject Resolution640x480Button;
    [SerializeField] private GameObject Resolution1280x720Button;
    [SerializeField] private GameObject Resolution1920x1080Button;
    [SerializeField] private GameObject FullScreenToggle;
    [SerializeField] private GameObject SoundEffectSlider;
    [SerializeField] private GameObject MusicSlider;
    [SerializeField] private GameObject WeaponSprite;



    // Start is called before the first frame update
    void Start()
    {
        ResumeButton.GetComponent<Button>().onClick.AddListener(gameManager.UnPause); // adds the unPause function to the button
        SettingsButton.GetComponent<Button>().onClick.AddListener(settingsButtonClick);
        QuitButton.GetComponent<Button>().onClick.AddListener(exitGame); // adds the exitGame function to the button, which is in this script

        LowSettingsButton.GetComponent<Button>().onClick.AddListener(changeQualityLow); // quality settings assignings
        MidSettingsButton.GetComponent<Button>().onClick.AddListener(changeQualityMid);
        HighSettingsButton.GetComponent<Button>().onClick.AddListener(changeQualityHigh);

        ChangeSettingsVisibility(false); // setting the quality setting buttons off by default
        ChangeButtonState(false);
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

    public void changeFullscreenbool()
    {
        isFullScreen = !isFullScreen;
    }
    
    public void ChangeButtonState(bool active)
    {
        ResumeButton.SetActive(active);
        SettingsButton.SetActive(active);
        QuitButton.SetActive(active);
    }

    private void settingsButtonClick()
    {
        if (!settingsActive)
            ChangeSettingsVisibility(true);
        else if (settingsActive)
            ChangeSettingsVisibility(false);
    }

    private void ChangeSettingsVisibility(bool active)
    {
        settingsActive = active;
        LowSettingsButton.SetActive(active);
        MidSettingsButton.SetActive(active);
        HighSettingsButton.SetActive(active);
        Resolution640x480Button.SetActive(active);
        Resolution1280x720Button.SetActive(active);
        Resolution1920x1080Button.SetActive(active);
        FullScreenToggle.SetActive(active);
        SoundEffectSlider.SetActive(active);
        MusicSlider.SetActive(active);
        WeaponSprite.SetActive(active);
    }

    void unpauseGame()
    {
        gameManager.UnPause();
    }

    void exitGame()
    {
        Application.Quit();
    }

    public void AssignUIElements(int lives, Pawn playerPawn)
    {
        pawn = playerPawn;
        UIHealthObject.GetComponent<UIHealthText>().pawnHealth = pawn.GetComponent<Health>();
        UILivesObject.GetComponent<UILivesDisplay>().livesRemaining = lives;
    }

    public void WeaponUIDisplay()
    {
        WeaponSprite.GetComponent<Image>().sprite = pawn.weaponToDisplay;
    }

    public void WeaponUIRemoveDisplay()
    {
        WeaponSprite.GetComponent<Image>().sprite = null;
    }

}
