using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks
{
    public class Tower:OrientedObject
    {
        public int Atack { get; set; }
        public int Defense { get; set; }
        public int Weight { get; set; }
        Barrel barrel;
        public Barrel Barrel { get { return barrel; } }
        public override void SetLocation(float x, float y)
        {
            base.SetLocation(x, y);
            barrel.SetLocation(Center.X, Center.Y - Rect.Height / 2 - barrel.Rect.Height / 2);
        }
        public Tower()
        {
            barrel = new Barrel();
            Draw += barrel.Draw;
        }
        public override void Move(float dx, float dy)
        {
            base.Move(dx, dy);
            barrel.Move(dx, dy);
        }

        public override void TurnDown()
        {
            base.TurnDown();
            barrel.SetLocation(Center.X, Center.Y+this.rect.Height/2 + barrel.Height / 2);
            barrel.TurnDown();
        }
        public override void TurnLeft()
        {
            base.TurnLeft();
            barrel.SetLocation(Center.X-rect.Width/2-barrel.Height/2, Center.Y);
            barrel.TurnLeft();
        }
        public override void TurnUp()
        {
            base.TurnUp();
            barrel.SetLocation(Center.X, Center.Y - this.rect.Height / 2 - barrel.Height / 2);
            barrel.TurnUp();
        }
        public override void TurnRight()
        {
            base.TurnRight();
            barrel.SetLocation(Center.X + rect.Width / 2 + barrel.Height / 2, Center.Y);
            barrel.TurnRight();
        }
       

    }
}
