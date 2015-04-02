using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace Tanks
{
    public class UserStrategy : TankStrategy
    {
        Control control;
        /// <summary>
        /// Up, Down, Left, Right
        /// </summary>
        byte[] moves = new byte[4] { 0, 0, 0, 0 }; 
        public UserStrategy(Tank arg, Field context, Control control)
        {
            this.arg = arg;
            this.context = context;
            this.control = control;
            InitStrategy();
        }

        public void InitStrategy()
        {
            control.KeyDown += new KeyEventHandler(ControlKeyDown);
            control.KeyUp += new KeyEventHandler(ControlKeyUp);
        }

        private void ControlKeyUp(object sender, KeyEventArgs e)
        {
            CheckKey(e.KeyCode, 0);
        }

        private void ControlKeyDown(object sender, KeyEventArgs e)
        {
            CheckKey(e.KeyCode, 1);
        }

        private void CheckKey(Keys key, byte value)
        {
            switch (key)
            {
                case Keys.Up: moves[0] = value; break;
                case Keys.Down: moves[1] = value; break;
                case Keys.Left: moves[2] = value; break;
                case Keys.Right: moves[3] = value; break;
            }
        }
        public override void Algorithm()
        {
            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i] == 1)
                {
                    switch (i)
                    {
                        case 0: arg.MoveUp(); break;
                        case 1: arg.MoveDown(); break;
                        case 2: arg.MoveLeft(); break;
                        case 3: arg.MoveRight(); break;
                    }
                }
            }
        }
    }
}
