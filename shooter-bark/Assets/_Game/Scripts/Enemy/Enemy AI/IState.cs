using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void EnterState(StateMachine machine);

    public void UpdateState(StateMachine machine);

    public void ExitState(StateMachine machine);
}
