using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    public void EnterState(StateMachine machine)
    {
Debug.Log("girdim");    }

    public void UpdateState(StateMachine machine)
    {
    }

    public void ExitState(StateMachine machine)
    {
Debug.Log("cıkıyom");
    }

   
}
