using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        // Apply saved settings
        SettingsManager.instance.LoadSettings();

        // Set player name in the game
        string playerName = SettingsManager.instance.playerName;

        // Spawn player
        SpawnPlayer(playerName);
    }

    void SpawnPlayer(string playerName)
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
            player.name = playerName;
        }
    }
}
