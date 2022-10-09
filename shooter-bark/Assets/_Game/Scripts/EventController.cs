using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
   public event Action<GameState> OnGameStateChanged;

   public void ExecuteGameStateChange(GameState state)
   {
      OnGameStateChanged?.Invoke(state);
   }
}
