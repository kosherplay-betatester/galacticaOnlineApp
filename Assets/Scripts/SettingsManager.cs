using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

    public float volume = 1.0f;
    public int graphicsQuality = 2;
    public string playerName = "Player";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float newVolume)
    {
        volume = newVolume;
        AudioListener.volume = volume;
    }

    public void SetGraphicsQuality(int newQuality)
    {
        graphicsQuality = newQuality;
        QualitySettings.SetQualityLevel(graphicsQuality);
    }

    public void SetPlayerName(string newName)
    {
        playerName = newName;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.SetInt("graphicsQuality", graphicsQuality);
        PlayerPrefs.SetString("playerName", playerName);
        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            volume = PlayerPrefs.GetFloat("volume");
            AudioListener.volume = volume;
        }
        if (PlayerPrefs.HasKey("graphicsQuality"))
        {
            graphicsQuality = PlayerPrefs.GetInt("graphicsQuality");
            QualitySettings.SetQualityLevel(graphicsQuality);
        }
        if (PlayerPrefs.HasKey("playerName"))
        {
            playerName = PlayerPrefs.GetString("playerName");
        }
    }
}
