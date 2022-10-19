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

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    void GetSaved()
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

    public IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2f);
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
