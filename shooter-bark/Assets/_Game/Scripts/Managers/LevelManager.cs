using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;


using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance => _instance;
    private static LevelManager _instance;
    public List<SceneAsset> m_SceneAssets = new List<SceneAsset>();

    public List<string> scenes;

    public int currentlevel;
    public int currentcurrency;

    public int LoadCount = 4;

    public event Action LoadNextLevel;
    public event Action<int, int> SetSave; 

    private void Awake()
    {
        GetSingleton();
        SavedInit();
    }

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    private void SavedInit()
    {
        
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 1);
        }
        if (!PlayerPrefs.HasKey("currency"))
        {
            PlayerPrefs.SetInt("currency", 0);
        }

        currentlevel = PlayerPrefs.GetInt("level");

        currentcurrency = PlayerPrefs.GetInt("currency");
    }

    public void SetSaved(int level, int currency)
    {
        currentlevel = level;
        currentcurrency = currency;
        PlayerPrefs.SetInt("level", currentlevel);
        PlayerPrefs.SetInt("currency", currentcurrency);
    }
    public IEnumerator LoadScene()
    {
        LoadNextLevel?.Invoke();
        yield return new WaitForSeconds(LoadCount);
        if (EditorBuildSettings.scenes.Length -1 < currentlevel)
        {
            SceneManager.LoadScene("Level " + currentlevel);
        }
        else
        {
            int randScene = Random.Range(1, currentlevel +1);
            SceneManager.LoadScene("Level " + randScene);
        }
    }
    
    void GetSingleton()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else DestroyImmediate(gameObject);
            
    }
}
