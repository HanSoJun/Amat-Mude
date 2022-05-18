using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveSystem : MonoBehaviour
{
    public string playerHealthKey = "PlayerHealth", sceneKey = "SceneIndex", savePresentKey = "SavePresent";

    public LoadedData loadedData { get; private set; }

    public UnityEvent<bool> OnDataLoadedResult;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        var result = LoadData();
        OnDataLoadedResult?.Invoke(result);
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteKey(playerHealthKey);
        PlayerPrefs.DeleteKey(sceneKey);
        PlayerPrefs.DeleteKey(savePresentKey);
        loadedData = null;
    }

    public bool LoadData()
    {
        if(PlayerPrefs.GetInt(savePresentKey) == 1)
        {
            loadedData = new LoadedData();
            loadedData.playerHealth = PlayerPrefs.GetInt(playerHealthKey);
            loadedData.sceneIndex = PlayerPrefs.GetInt(sceneKey);
            return true;
        }
        return false;
    }

    public void SaveData(int sceneIndex, int playerHealth)
    {
        if (loadedData == null)
            loadedData = new LoadedData();
        loadedData.playerHealth = playerHealth;
        loadedData.sceneIndex = sceneIndex;
        PlayerPrefs.SetInt(playerHealthKey, playerHealth);
        PlayerPrefs.SetInt(sceneKey, sceneIndex);
        PlayerPrefs.SetInt(savePresentKey, 1);
    }
}

public class LoadedData
{
    public int playerHealth = -1;
    public int sceneIndex = -1;
}

