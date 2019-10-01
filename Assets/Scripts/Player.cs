using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actable
{

    protected override Phase waitPhase {
        get {
            return Phase.UserWait;
        }
    }

    protected override Phase actPhase {
        get {
            return Phase.UserAct;
        }
    }

    protected override Phase nextPhase {
        get {
            return Phase.EnemyWait;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.phase != waitPhase)
            return;
        var action = Decide();
        Act(action);
    }

    protected override Action Decide(){
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

    protected override void Act(Action action)
    {
        switch(action)
        {
            case MoveAction m:
                GameManager.instance.phase = actPhase;
                Move(m.direction);
                return;
            case NoAction _:
            default:
                GameManager.instance.phase = waitPhase;
                return;
        }
    }
}
