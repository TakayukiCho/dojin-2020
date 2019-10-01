using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actable
{
    protected override Phase waitPhase { get { return Phase.EnemyWait; } }

    protected override Phase actPhase { get { return Phase.EnemyAct; } }

    protected override Phase nextPhase { get { return Phase.UserWait; } }

    void Update()
    {
        if(GameManager.instance.phase != Phase.EnemyWait)
            return;
        var action = Decide();
        GameManager.instance.phase = actPhase;
        Act(action, OnActStart, OnActComplete, OnNoAction);
    }

    protected override BaseAction Decide(){
        var initialAction = MoveAction.GetRandom();
         switch(initialAction)
        {
            case MoveAction m:
                if (!CanMove(m.direction))
                    return new NoAction();
                return m;
            default:
                return initialAction;
        }
    }

    private void OnActStart(){
        GameManager.instance.phase = Phase.EnemyAct;
    }

    private void OnActComplete(){
        GameManager.instance.phase = Phase.UserWait;
    }

    private void OnNoAction(){
        GameManager.instance.phase = Phase.UserWait;
    }

}
