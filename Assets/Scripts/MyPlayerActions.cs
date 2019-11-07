using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;

public class MyPlayerActions : PlayerActionSet
{
    public PlayerAction Right;
    public PlayerAction Left;
    public PlayerAction Up;
    public PlayerAction Down;
    public PlayerTwoAxisAction Move;
    
    public PlayerAction Shoot;

    public PlayerAction RRight;
    public PlayerAction RUp;
    public PlayerAction RLeft;
    public PlayerAction RDown;
    public PlayerTwoAxisAction Rotate;

    public MyPlayerActions()
    {
        Right = CreatePlayerAction("Right");
        Left = CreatePlayerAction("Left");
        Up = CreatePlayerAction("Up");
        Down = CreatePlayerAction("Down");
        Move = CreateTwoAxisPlayerAction(Left, Right, Down, Up);

        RRight = CreatePlayerAction("RRight");
        RUp = CreatePlayerAction("RUp");
        RDown = CreatePlayerAction("RDown");
        RLeft = CreatePlayerAction("RLeft");
        Rotate = CreateTwoAxisPlayerAction(RLeft, RRight, RDown, RUp);
        
        Shoot = CreatePlayerAction("Shoot");
        
        CreateDefaultBindings();
    }

    private void CreateDefaultBindings()
    {
        Right.AddDefaultBinding(Key.D);
        Right.AddDefaultBinding(InputControlType.LeftStickRight);
        Right.AddDefaultBinding(InputControlType.DPadRight);
        
        Left.AddDefaultBinding(Key.A);
        Left.AddDefaultBinding(InputControlType.LeftStickLeft);
        Left.AddDefaultBinding(InputControlType.DPadLeft);
        
        Up.AddDefaultBinding(Key.W);
        Up.AddDefaultBinding(InputControlType.LeftStickUp);
        Up.AddDefaultBinding(InputControlType.DPadUp);
        
        Down.AddDefaultBinding(Key.S);
        Down.AddDefaultBinding(InputControlType.LeftStickDown);
        Down.AddDefaultBinding(InputControlType.DPadDown);
        
        Shoot.AddDefaultBinding(Key.Space);
        Shoot.AddDefaultBinding(InputControlType.Action1);
        Shoot.AddDefaultBinding(InputControlType.RightTrigger);
        
        RUp.AddDefaultBinding(InputControlType.RightStickUp);
        RUp.AddDefaultBinding(Key.UpArrow);
        RDown.AddDefaultBinding(InputControlType.RightStickDown);
        RDown.AddDefaultBinding(Key.DownArrow);
        RLeft.AddDefaultBinding(InputControlType.RightStickLeft);
        RLeft.AddDefaultBinding(Key.LeftArrow);
        RRight.AddDefaultBinding(InputControlType.RightStickRight);
        RRight.AddDefaultBinding(Key.RightArrow);
    }
}
