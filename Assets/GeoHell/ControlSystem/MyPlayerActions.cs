using InControl;

namespace GeoHell.ControlSystem
{
    /// <summary>
    /// A set of defined controller action that are used by the GameplayController
    /// </summary>
    public class MyPlayerActions : PlayerActionSet
    {
        public readonly PlayerAction Right;
        public readonly PlayerAction Left;
        public readonly PlayerAction Up;
        public readonly PlayerAction Down;
        public readonly PlayerTwoAxisAction Move;
    
        public readonly PlayerAction Shoot;

        public readonly PlayerAction RRight;
        public readonly PlayerAction RUp;
        public readonly PlayerAction RLeft;
        public readonly PlayerAction RDown;
        public readonly PlayerTwoAxisAction Rotate;

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
}
