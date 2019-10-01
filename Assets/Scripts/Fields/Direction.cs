using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
    Up = 0,
    Down,
    Left,
    Right,
    None,
}

static class DirectionHelper
{
    public static Vector3 GetVector3(this Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return new Vector3(0, 1);
            case Direction.Down:
                return new Vector3(0, -1);
            case Direction.Right:
                return new Vector3(1, 0);
            case Direction.Left:
                return new Vector3(-1, 0);
            default:
                return new Vector3(0, 0);
        }
    }

    public static Direction GetRandom(){
        return (Direction)Random.Range(0, 3);
    }
}
