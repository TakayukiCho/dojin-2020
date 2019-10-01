using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actable
{
    protected override Phase waitPhase {
        get {
            return Phase.EnemyWait;
        }
    }

    protected override Phase actPhase {
        get {
            return Phase.EnemyAct;
        }
    }

    protected override Phase nextPhase {
        get {
            return Phase.UserWait;
        }
    }

    void Update()
    {
        if(GameManager.instance.phase != waitPhase)
            return;
        var action = Decide();
        GameManager.instance.phase = actPhase;
        Act(action);
    }

    protected override Action Decide(){
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

    protected override void Act(Action action)
    {
        switch(action)
        {
            case MoveAction m:
                Move(m.direction);
                return;
            case NoAction _:
            default:
                GameManager.instance.phase = nextPhase;
                return;
        }
    }
}
