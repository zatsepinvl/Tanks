using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tanks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        Tank t;
        private void Form1_Load(object sender, EventArgs e)
        {
            TankDirector d = new TankDirector();
            t = d.Construct(new IBuilder<Tank>[1] { new TankDefaultBuilder() });
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            t.Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left: t.MoveLeft(); break;
                case Keys.Right: t.MoveRight(); break;
                case Keys.Up: t.MoveUp(); break;
                case Keys.Down: t.MoveDown(); break;
            }
            Refresh();
        }
    }
}
