using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class MainWindow : Form
    {
        Emitter emitter;
        bool timeStopped = false;

        public MainWindow()
        {
            InitializeComponent();

            emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.5f
            };

            // Привязка изображения к pb
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!timeStopped)
            {
                emitter.UpdateState();
            }

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }

            // Обновление pb
            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            emitter.impactPoint.X = e.X;
            emitter.impactPoint.Y = e.Y;
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            timeStopped = !timeStopped;
            if (timeStopped)
            {
                timer1.Interval = 40;
            }
            else
            {
                timer1.Interval = timeTB.Value;
            }
    }

        private void stepBtn_Click(object sender, EventArgs e)
        {
            if (timeStopped)
            {
                var g = Graphics.FromImage(picDisplay.Image);
                emitter.UpdateState();
                g.Clear(Color.Black);
                emitter.Render(g);
                picDisplay.Invalidate();
            }
        }

        private void timeTB_Scroll(object sender, EventArgs e)
        {
            if (!timeStopped)
            {
                timer1.Interval = timeTB.Value;
            }
        }

        private void vectorsBtn_Click(object sender, EventArgs e)
        {
            emitter.vectorsMode = !emitter.vectorsMode;
        }

        private void picDisplay_Click(object sender, EventArgs e)
        {
            if (emitter.impactPoint is AntiGravityPoint)
            {
                emitter.impactPoint = new GravityPoint();
            }
            else
            {
                emitter.impactPoint = new AntiGravityPoint();
            }
        }
    }
}
