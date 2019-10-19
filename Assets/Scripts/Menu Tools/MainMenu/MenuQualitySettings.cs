using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class MenuQualitySettings : MonoBehaviour
{
    private const string RESOLUTION_PREF_KEY = "resolution";
    private const string WINDOWMODE_PREF_KEY = "windowMode";
    private const string QUALITY_PREF_KEY = "quality";
    private const string VSYNC_PREF_KEY = "vSync";
    private const string MASTERVOLUME_PREF_KEY = "masterVolume";

    [SerializeField]
    private TextMeshProUGUI resolutionText, windowModeText, qualityText, vSyncText, masterVolumeText;

    [SerializeField]
    private Button resolutionButton, windowModeButton, qualityButton, vSyncButton, masterVolumeButton, applyButton, resetButton;

    private Resolution[] resolutions;
    private int currentResolutionIndex = 0;

    private int windowMode;

    private string[] qualityNames;
    private int qualityIndex = 0;

    private int vSync;

    private int masterVolume;

    public Player player;

    public MenuObjectSelector mainMenu;
    public MenuLightController lightController;


    private void Start()
    {
        player = ReInput.players.GetPlayer(1);

        try
        {

            //resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
            resolutions = Screen.resolutions;
            currentResolutionIndex = PlayerPrefs.GetInt(RESOLUTION_PREF_KEY, resolutions.Length - 1);
            SetResolutionText(resolutions[currentResolutionIndex]);

            windowMode = PlayerPrefs.GetInt(WINDOWMODE_PREF_KEY, 0);
            SetWindowModeText();

            qualityNames = QualitySettings.names;
            qualityIndex = PlayerPrefs.GetInt(QUALITY_PREF_KEY, QualitySettings.names.Length - 1);
            SetQualityText();

            vSync = PlayerPrefs.GetInt(VSYNC_PREF_KEY, 1);
            SetVSyncText();

            masterVolume = PlayerPrefs.GetInt(MASTERVOLUME_PREF_KEY, 100);
            SetMasterVolumeText();

            if (!GamePrefs.HasAppliedSettings)
            {
                GamePrefs.HasAppliedSettings = true;
                ApplySettings();
                gameObject.SetActive(false);
            }
        }
        catch(Exception e)
        {
            Debug.Log(e);
            ResetSettings();
        }
    }

    private void OnEnable()
    {
        resolutionButton.Select();
        if (mainMenu)
        {
            mainMenu.enabled = false;
            lightController.enabled = false;
        }
    }

    private void OnDisable()
    {
        if (mainMenu)
        {
            mainMenu.enabled = true;
            lightController.enabled = true;
        }
    }

    private void Update()
    {
        if (player.GetButtonDown("Left"))
        {
            if (EventSystem.current.currentSelectedGameObject == resolutionButton.gameObject)
            {
                SetPreviousResolution();
            }
            else if (EventSystem.current.currentSelectedGameObject == windowModeButton.gameObject)
            {
                ChangeWindowMode();
            }
            else if (EventSystem.current.currentSelectedGameObject == qualityButton.gameObject)
            {
                SetPreviousQuality();
            }
            else if (EventSystem.current.currentSelectedGameObject == vSyncButton.gameObject)
            {
                ChangeVSyncMode();
            }
            else if (EventSystem.current.currentSelectedGameObject == masterVolumeButton.gameObject)
            {
                DecreaseMasterVolume();
            }
            else if (EventSystem.current.currentSelectedGameObject == applyButton.gameObject && resetButton != null)
            {
                resetButton.Select();
            }
            else if (EventSystem.current.currentSelectedGameObject == resetButton.gameObject)
            {
                applyButton.Select();
            }
        }

        if (player.GetButtonDown("Right"))
        {
            if (EventSystem.current.currentSelectedGameObject == resolutionButton.gameObject)
            {
                SetNextResolution();
            }
            else if (EventSystem.current.currentSelectedGameObject == windowModeButton.gameObject)
            {
                ChangeWindowMode();
            }
            else if (EventSystem.current.currentSelectedGameObject == qualityButton.gameObject)
            {
                SetNextQuality();
            }
            else if (EventSystem.current.currentSelectedGameObject == vSyncButton.gameObject)
            {
                ChangeVSyncMode();
            }
            else if (EventSystem.current.currentSelectedGameObject == masterVolumeButton.gameObject)
            {
                IncreaseMasterVolume();
            }
            else if (EventSystem.current.currentSelectedGameObject == applyButton.gameObject && resetButton != null)
            {
                resetButton.Select();
            }
            else if (EventSystem.current.currentSelectedGameObject == resetButton.gameObject)
            {
                applyButton.Select();
            }
        }

        if (player.GetButtonDown("Up"))
        {
            if (EventSystem.current.currentSelectedGameObject == resolutionButton.gameObject)
            {
                applyButton.Select();
            }
            else if (EventSystem.current.currentSelectedGameObject == windowModeButton.gameObject)
            {
                resolutionButton.Select();
            }
            else if (EventSystem.current.currentSelectedGameObject == qualityButton.gameObject)
            {
                windowModeButton.Select();
            }
            else if (EventSystem.current.currentSelectedGameObject == vSyncButton.gameObject)
            {
                qualityButton.Select();
            }
            else if (EventSystem.current.currentSelectedGameObject == masterVolumeButton.gameObject)
            {
                vSyncButton.Select();
            }
            else
            {
                masterVolumeButton.Select();
            }
        }

        if (player.GetButtonDown("Down"))
        {
            if (EventSystem.current.currentSelectedGameObject == resolutionButton.gameObject)
            {
                windowModeButton.Select();
            }
            else if (EventSystem.current.currentSelectedGameObject == windowModeButton.gameObject)
            {
                qualityButton.Select();
            }
            else if (EventSystem.current.currentSelectedGameObject == qualityButton.gameObject)
            {
                vSyncButton.Select();
            }
            else if (EventSystem.current.currentSelectedGameObject == vSyncButton.gameObject)
            {
                masterVolumeButton.Select();
            }
            else if (EventSystem.current.currentSelectedGameObject == masterVolumeButton.gameObject)
            {
                applyButton.Select();
            }
            else
            {
                resolutionButton.Select();
            }
        }

        if (player.GetButtonDown("A"))
        {
            if (EventSystem.current.currentSelectedGameObject == applyButton.gameObject)
            {
                ApplySettings();
            }
            if (EventSystem.current.currentSelectedGameObject == resetButton.gameObject && resetButton != null)
            {
                ResetSettings();
            }
        }

        if (player.GetButtonDown("B") || player.GetButtonDown("Back"))
        {
            gameObject.SetActive(false);
        }
    }

    #region Apply Settings

    public void ApplySettings()
    {
        PlayerPrefs.SetInt(RESOLUTION_PREF_KEY, currentResolutionIndex);
        Screen.SetResolution(resolutions[currentResolutionIndex].width, resolutions[currentResolutionIndex].height, SetWindowMode(windowMode), resolutions[currentResolutionIndex].refreshRate);
        SetQualityLevel();
        SetVSyncMode();
        SetMasterVolume();
        gameObject.SetActive(false);
    }

    #endregion

    #region Reset Settings

    public void ResetSettings()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #endregion

    #region Resolution

    private void SetResolutionText(Resolution resolution)
    {
        resolutionText.text = resolution.width + "x" + resolution.height + " @ " + resolution.refreshRate + "hz";
    }

    private void SetNextResolution()
    {
        currentResolutionIndex = GetNextWrappedIndex(resolutions, currentResolutionIndex);
        SetResolutionText(resolutions[currentResolutionIndex]);
    }

    private void SetPreviousResolution()
    {
        currentResolutionIndex = GetPreviousWrappedIndex(resolutions, currentResolutionIndex);
        SetResolutionText(resolutions[currentResolutionIndex]);
    }
    #endregion

    #region WindowMode

    private FullScreenMode SetWindowMode(int mode)
    {
        PlayerPrefs.SetInt(WINDOWMODE_PREF_KEY, windowMode);

        if (mode == 0)
        {
            return FullScreenMode.FullScreenWindow;
        }
        else
        {
            return FullScreenMode.Windowed;
        }
    }

    private void SetWindowModeText()
    {
        if (windowMode == 1)
        {
            windowModeText.text = "Windowed";
        }
        else
        {
            windowModeText.text = "Fullscreen";
        }
    }

    private void ChangeWindowMode()
    {
        if (windowMode == 0)
        {
            windowMode = 1;
        }
        else
        {
            windowMode = 0;
        }
        SetWindowModeText();
    }

    #endregion

    #region Quality

    private void SetQualityLevel()
    {
        PlayerPrefs.SetInt(QUALITY_PREF_KEY, qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    private void SetQualityText()
    {
        qualityText.text = qualityNames[qualityIndex];
    }

    private void SetNextQuality()
    {
        qualityIndex = GetNextWrappedIndex(qualityNames, qualityIndex);
        SetQualityText();
    }

    private void SetPreviousQuality()
    {
        qualityIndex = GetPreviousWrappedIndex(qualityNames, qualityIndex);
        SetQualityText();
    }

    #endregion

    #region vSync

    private void SetVSyncText()
    {
        if (vSync == 0)
        {
            vSyncText.text = "Off";
        }
        else
        {
            vSyncText.text = "On";
        }
    }

    private void SetVSyncMode()
    {
        PlayerPrefs.SetInt(VSYNC_PREF_KEY, vSync);
        if (vSync == 0)
        {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
        }
        else
        {
            QualitySettings.vSyncCount = 1;
        }
    }

    private void ChangeVSyncMode()
    {
        if (vSync == 0)
        {
            vSync = 1;
        }
        else
        {
            vSync = 0;
        }
        SetVSyncText();
    }

    #endregion

    #region Master Volume

    private void SetMasterVolumeText()
    {
        masterVolumeText.text = masterVolume.ToString();
    }

    private void SetMasterVolume()
    {
        PlayerPrefs.SetInt(MASTERVOLUME_PREF_KEY, masterVolume);
        AudioListener.volume = (float)masterVolume / 100f;
        Debug.Log("Volume: " + AudioListener.volume);
    }

    private void IncreaseMasterVolume()
    {
        if (masterVolume != 100)
        {
            masterVolume += 10;
        }
        SetMasterVolumeText();
        SetMasterVolume();
    }

    private void DecreaseMasterVolume()
    {
        if (masterVolume != 0)
        {
            masterVolume -= 10;
        }
        SetMasterVolumeText();
        SetMasterVolume();
    }

    #endregion

    #region Utils

    private int GetNextWrappedIndex<T>(IList<T> collection, int currentIndex)
    {
        if (collection.Count < 1) return 0;
        return (currentIndex + 1) % collection.Count;
    }

    private int GetPreviousWrappedIndex<T>(IList<T> collection, int currentIndex)
    {
        if (collection.Count < 1) return 0;
        if ((currentIndex - 1) < 0) return collection.Count - 1;
        return (currentIndex - 1) % collection.Count;
    }

    #endregion
}
