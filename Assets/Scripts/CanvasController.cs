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

    public GameObject FPSDisplay;

    private bool isFullScreen = false;
    private bool settingsActive = false;

    public GameObject WeaponSprite;



    // Start is called before the first frame update
    void Start()
    {
        WeaponSprite.SetActive(false);
        ResumeButton.GetComponent<Button>().onClick.AddListener(gameManager.UnPause); // adds the unPause function to the button
        SettingsButton.GetComponent<Button>().onClick.AddListener(settingsButtonClick);
        QuitButton.GetComponent<Button>().onClick.AddListener(exitGame); // adds the exitGame function to the button, which is in this script

        ChangeButtonState(false);

        optionsMenu = this.gameObject.GetComponent<OptionsMenu>();

        ChangeSettingsVisibility(false); // setting the quality setting buttons off by default
        ChangeButtonState(false);
    }

    public void Update()
    {
        if (gameManager.isPaused)
            return;
        FPSDisplay.GetComponent<Text>().text = string.Format("FPS: " + Mathf.RoundToInt(1.0f / Time.deltaTime));
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
        Screen.fullScreen = !Screen.fullScreen;
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
        optionsMenu.changeVisibility(active);
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
        WeaponSprite.SetActive(true);
        WeaponSprite.GetComponent<Image>().sprite = pawn.weaponToDisplay;
    }

    public void WeaponUIRemoveDisplay()
    {
        WeaponSprite.GetComponent<Image>().sprite = null;
        WeaponSprite.SetActive(false);
    }

}
