using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
    Up,
    Down,
    Left,
    Right,
    None,
}

static class DirectionMethods
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
}

public class InputManager
{
    public static Direction getDirection(){
        var vertical = (int) Input.GetAxisRaw("Vertical") ;
        var horizontal = (int) Input.GetAxisRaw("Horizontal");

        if(vertical > 0){
            return Direction.Up;
        }else if (vertical < 0) {
            return Direction.Down;
        }else if (horizontal > 0) {
            return Direction.Right;
        }else if (horizontal < 0 ){
            return Direction.Left;
        }
        return Direction.None;
    }
}
