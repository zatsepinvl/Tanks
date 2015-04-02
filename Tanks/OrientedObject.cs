using System;
using System.Drawing;

namespace Tanks
{
    public enum MotionDirection
    {
        Left,
        Right,
        Up,
        Down
    }
    public class OrientedObject:TextureObject
    {
        public MotionDirection Direction { get; set; }
        public PointF Center { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public OrientedObject():base()
        {
            Direction = MotionDirection.Up;
        }
        public override void SetLocation(float x, float y)
        {
            Center = new PointF(x, y);
            base.SetLocation(x-rect.Width/2,y-rect.Height/2);
        }
        public override void Move(float dx, float dy)
        {
            Center = new PointF(Center.X + dx, Center.Y + dy);
            base.Move(dx, dy);
        }
        public override void SetSize(SizeF size)
        {
            Center = new PointF(Center.X + (-rect.Width + size.Width)/2, Center.Y + (-rect.Height + size.Height)/2);
            Width = size.Width;
            Height = size.Height;
            base.SetSize(size);
        }
        public virtual void TurnUp()
        {
            Direction = MotionDirection.Up;
            base.SetLocation(Center.X - Width / 2, Center.Y - Height / 2);
            base.SetSize(new SizeF(Width, Height));
        }
        public virtual void TurnLeft()
        {
            Direction = MotionDirection.Left;
            base.SetLocation(Center.X - Height / 2, Center.Y - Width / 2);
            base.SetSize(new SizeF(Height, Width));
        }
        public virtual void TurnRight()
        {
            //base.SetLocation(Center.X + Height / 2, Center.Y + Width / 2);
            //base.SetSize(new SizeF(Width, -Height));
            TurnLeft();
            Direction = MotionDirection.Right;
        }
        public virtual void TurnDown()
        {
            TurnUp();
            Direction = MotionDirection.Down;
        }

    }
}
