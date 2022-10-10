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

        public event Action <GameState> OnGameStateChanged;

        public void SetGameState(GameState state)
        { Debug.Log(state +" oldu stateimiz");
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
        void GetSingleton()
        {
            if (_instance == null) _instance = this;
            else DestroyImmediate(gameObject);
            
            }
        
    }
}
