using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Dropdown graphicsDropdown;
    public InputField playerNameInput;

    void Start()
    {
        // Load settings
        SettingsManager.instance.LoadSettings();

        // Initialize UI elements with saved settings
        volumeSlider.value = SettingsManager.instance.volume;
        graphicsDropdown.value = SettingsManager.instance.graphicsQuality;
        playerNameInput.text = SettingsManager.instance.playerName;
    }

    public void OnVolumeChange(float newVolume)
    {
        SettingsManager.instance.SetVolume(newVolume);
    }

    public void OnGraphicsChange(int newQuality)
    {
        SettingsManager.instance.SetGraphicsQuality(newQuality);
    }

    public void OnPlayerNameChange(string newName)
    {
        SettingsManager.instance.SetPlayerName(newName);
    }

    public void OnSaveButtonClick()
    {
        SettingsManager.instance.SaveSettings();
    }
}
