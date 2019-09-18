using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Components
{
    public enum Facing
    {
        Left, Right, Up, Down
    }

    public enum State
    {
        Idle,
        Walking
    }

    public class Player
    {
        public Facing Facing { get; set; } = Facing.Right;
        public State State { get; set; }
        public bool CanJump => State == State.Idle || State == State.Walking;
    }
}
