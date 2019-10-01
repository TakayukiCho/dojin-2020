using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : BaseAction
{
    public Direction direction;

    public MoveAction(Direction direction){
        this.direction = direction;
    }

    public static MoveAction GetRandom() {
        return new MoveAction(DirectionHelper.GetRandom());
    }
}
