using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actable
{
    void Update()
    {
        if(GameManager.instance.phase != Phase.EnemyWait)
            return;
        var action = Decide();
        Act(action, OnActStart, OnActComplete, OnNoAction);
    }

    protected BaseAction Decide(){
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
