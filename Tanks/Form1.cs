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
        Timer timer = new Timer();
        private void Form1_Load(object sender, EventArgs e)
        {
            TankDirector d = new TankDirector();
            t = d.Construct(new IBuilder<Tank>[] { new TankDefaultBuilder(), new TankUserBuilder(this) });
            timer.Interval = 20;
            timer.Tick += new EventHandler(timer_Tick);
            Timer refresher = new Timer();
            refresher.Interval = 10;
            refresher.Tick += new EventHandler(refresher_Tick);
            //refresher.Start();
            timer.Start();
        }

        void refresher_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            t.Tick();
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            t.Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
