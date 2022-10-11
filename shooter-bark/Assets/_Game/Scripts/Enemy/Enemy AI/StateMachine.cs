using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public IState currentstate;

    public PatrolState patrolstate = new PatrolState();

    public AttackState attackstate = new AttackState();

    private void Start()
    {
        currentstate = patrolstate;
        currentstate.EnterState(this);
    }

    private void Update()
    {
        currentstate.UpdateState(this);
    }

    public void SwitchState(IState state)
    {
        currentstate.ExitState(this);

        currentstate = state;
        
        currentstate.EnterState(this);
    }
    
}
