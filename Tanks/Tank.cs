using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tanks
{

    public class Tank:IGameObject
    {
        protected int health;
        public int Health
        {
            get { return health; }
            set
            {
                health = value;
                if (HealthChanged != null) { HealthChanged(this); }
                if (health <= 0) { if (Dead != null) { Dead(this); } }
            }
        }
        public int Speed { get; set; }

        public Tower Tower { get; set; }
        public Engine Engine { get; set; }
        public Body Body { get; set; }

        protected MotionDirection direction;
        public MotionDirection Direction { get { return direction; } }

        protected TankState state;
        public TankState State
        {
            get { return state; }
            set
            {
                state = value; if (StateChanged != null)
                {
                    StateChanged(this);
                }
            }
        }

        public TankStrategy Strategy { get; set; }

        public event Action<Tank> HealthChanged;
        public event Action<Tank> StateChanged;
        public event Action<Tank> Dead;

        public Tank()
        {
            direction = MotionDirection.Up;
            State = new TankStateLiving(this);
        }

        public virtual void Tick()
        {
            if (Strategy != null)
            {
                Strategy.Algorithm();
            }
        }

        public void Draw(Graphics g)
        {
            Body.Draw(g);
            Tower.Draw(g);
        }

        

        public void MoveUp()
        {
            if (Direction != MotionDirection.Up)
            {
                TurnUp();
            }
            Body.Move(0, -Speed);
            Tower.Move(0, -Speed);
        }
        public void MoveDown()
        {
            if (Direction != MotionDirection.Down)
            {
                TurnDown();
            }
            Body.Move(0, Speed);
            Tower.Move(0, Speed);
        }
        public void MoveRight()
        {
            if (Direction != MotionDirection.Right)
            {
                TurnRight();
            }
            Body.Move(Speed, 0);
            Tower.Move(Speed, 0);
        }

        public void MoveLeft()
        {
            if (Direction != MotionDirection.Left)
            {
                TurnLeft();
            }
            Body.Move(-Speed, 0);
            Tower.Move(-Speed, 0);
        }

        public void TurnLeft()
        {
            direction = MotionDirection.Left;
            Body.TurnLeft();
            Tower.TurnLeft();
        }

        public void TurnRight()
        {
            direction = MotionDirection.Right;
            Body.TurnRight();
            Tower.TurnRight();
        }

        public void TurnUp()
        {
            direction = MotionDirection.Up;
            Body.TurnUp();
            Tower.TurnUp();
        }

        public void TurnDown()
        {
            direction = MotionDirection.Down;
            Body.TurnDown();
            Tower.TurnDown();
        }
        
        public void SetLocation(float x, float y)
        {
            Body.SetLocation(x, y);
            Tower.SetLocation(Body.Rect.X + Body.Rect.Width / 2, Body.Rect.Y + Body.Rect.Height / 2);
        }


    }
}
