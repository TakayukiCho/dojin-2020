using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actable
{

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.phase != Phase.UserWait)
            return;
        var action = Decide();
        Act(action, OnActStart, OnActComplete, OnNoAction);
    }

    protected BaseAction Decide(){
        var initialAction = InputManager.GetAction();
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
        GameManager.instance.phase = Phase.UserAct;
    }
    private void OnActComplete(){
        GameManager.instance.phase = Phase.EnemyWait;
    }
    private void OnNoAction(){
        GameManager.instance.phase = Phase.UserWait;
    }
}
