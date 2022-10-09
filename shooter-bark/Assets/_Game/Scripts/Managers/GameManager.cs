using System;
using System.Collections;
using UnityEngine;

namespace _Game.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager instance => _instance;

        public event Action <GameState> OnGameStateChanged;

        public void SetGameState(GameState state)
        {
            Debug.Log("state degisti: "+ state);
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
            StartCoroutine(changeit());
        }

        // ReSharper disable Unity.PerformanceAnalysis
        IEnumerator changeit()
        {
            yield return new WaitForSeconds(2f);
            SetGameState(GameState.Started);
        }

        void GameStateChanged(GameState state)
        {
            
        }

        void GetSingleton()
        {
            if (_instance == null) _instance = this;
            else DestroyImmediate(gameObject);
            
            }
        
    }
}
