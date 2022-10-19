using System;
using System.Collections;
using UnityEngine;

namespace _Game.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager instance => _instance;

        [SerializeField] private PanelsController panelscontroller;

        public EnemiesData enemiesdata;

        public LevelSettingsSO leveldata;
        public event Action onPaused;
        public event Action onContinue;
        public event Action onRetry;

        public event Action<int, int> changeSaveData;
        public event Action <GameState> OnGameStateChanged;


        public Transform player => GameObject.FindGameObjectWithTag("Player").transform;

        public void SetGameState(GameState state)
        { 
            Debug.Log(state +" oldu stateimiz");
            OnGameStateChanged?.Invoke(state);
        }

        

        
        
        private void Awake()
        {
            GetSingleton();
            
            OnGameStateChanged += GameStateChanged;
        }

        private void OnDestroy()
        {
            OnGameStateChanged -= GameStateChanged;
        }

        private void Start()
        {
            SetGameState(GameState.TapToStart);
        }

       

        void GameStateChanged(GameState state)
        {
            switch (state)
            {
                case(GameState.TapToStart):
                    GameOpened();
                    break;
                case(GameState.Started):
                    GameStarted();
                    break;
                case(GameState.Finished):
                    break;
                case(GameState.Win):
                    break;
                case(GameState.Fail):
                    break;
            }
        }

        void GameOpened()
        {
            
        }

        void GameStarted()
        {
            StartCoroutine(spawnWave());

        }
        
        public void PauseGame()
        {
            Time.timeScale = 0f;
            onPaused?.Invoke();
            
        }

        public void ContinueGame()
        {
            Time.timeScale = 1f;
            onContinue?.Invoke();
        }

        IEnumerator spawnWave()
        {
            yield return new WaitForSeconds(2f);
            EnemySpawner.instance.executeSpawnWave();

        }

        private void GetSaveData()
        {
            int currentlevel, currentcurreny;
            if (PlayerPrefs.HasKey("level"))
            {
                currentlevel = PlayerPrefs.GetInt("level");
            }
            else
            {
                PlayerPrefs.SetInt("level", 1);
                currentlevel = PlayerPrefs.GetInt("level");
            }
        }
        
        void GetSingleton()
        {
            if (_instance == null) _instance = this;
            else DestroyImmediate(gameObject);
            
            }
        
    }
}
