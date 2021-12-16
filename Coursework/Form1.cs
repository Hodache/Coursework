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
            emitter.MouseX = e.X;
            emitter.MouseY = e.Y;
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            timeStopped = !timeStopped;
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
            timer1.Interval = timeTB.Value;
        }

        private void vectorsBtn_Click(object sender, EventArgs e)
        {
            emitter.debugMode = !emitter.debugMode;
        }
    }
}
