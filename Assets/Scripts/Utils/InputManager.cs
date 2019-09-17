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
