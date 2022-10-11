using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    
    public void EnterState(StateMachine machine)
    {
        Debug.Log("attack a girdim");
    }

    public void UpdateState(StateMachine machine)
    {
        throw new System.NotImplementedException();
    }

    public void ExitState(StateMachine machine)
    {
        throw new System.NotImplementedException();
    }
}
