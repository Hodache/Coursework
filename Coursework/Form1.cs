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
            var g = Graphics.FromImage(picDisplay.Image);

            if (!timeStopped)
            {
                emitter.UpdateState(g);
            }

                g.Clear(Color.Black);
                emitter.Render(g);

            // Обновление pb
            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (emitter.impactPoint != null)
            {
                emitter.impactPoint.X = e.X;
                emitter.impactPoint.Y = e.Y;
            }

            emitter.MouseX = e.X;
            emitter.MouseY = e.Y;
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
                emitter.UpdateState(g);

                g.Clear(Color.Black);
                emitter.Render(g);

                picDisplay.Invalidate();
            }
        }

        private void timeTB_Scroll(object sender, EventArgs e)
        {
            if (timeStopped)
            {
                timer1.Interval = 40;
            }
            else
            {
                timer1.Interval = timeTB.Value;
            }
        }

        private void vectorsBtn_Click(object sender, EventArgs e)
        {
            emitter.vectorsMode = !emitter.vectorsMode;
        }

        private void picDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (emitter.impactPoint == null)
                {
                    emitter.impactPoint = new GravityPoint();
                }
                else if (emitter.impactPoint is GravityPoint)
                {
                    emitter.impactPoint = new AntiGravityPoint();
                }
                else
                {
                    emitter.impactPoint = null;
                }
            }
            else if(e.Button == MouseButtons.Right && emitter.counters.Count < 6)
            {
                emitter.counters.Add(new ParticleCounter {
                                        X = e.X,
                                        Y = e.Y,
                                        Radius = 50
                                    });
            }
            else if (e.Button == MouseButtons.Middle)
            {
                emitter.counters.Clear();
            }
            
        }

        private void circleTB_Scroll(object sender, EventArgs e)
        {
            emitter.ColoringCircle.X = picDisplay.Width * ((float)circleTB.Value / 100);
        }
    }
}
