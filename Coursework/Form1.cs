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
    public partial class Form1 : Form
    {
        List<Particle> particles = new List<Particle>(); // Список частиц
        private int MouseX = 0;
        private int MouseY = 0;

        public Form1()
        {
            InitializeComponent();

            // Привязка изображения к pb
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
        }

        // Пересчет состояния системы
        private void UpdateState()
        {
            // Пересчет свойств частиц
            foreach (var particle in particles)
            {
                particle.Life--;

                if (particle.Life < 0)
                {
                    particle.Life = 20 + Particle.rnd.Next(100);
                    particle.Direction = Particle.rnd.Next(360);
                    particle.Speed = 1 + Particle.rnd.Next(10);
                    particle.Radius = 2 + Particle.rnd.Next(10);

                    particle.X = MouseX;
                    particle.Y = MouseY;
                }
                else
                {
                    var directionInRadians = particle.Direction / 180 * Math.PI;

                    particle.X += (float)(particle.Speed * Math.Cos(directionInRadians));
                    particle.Y -= (float)(particle.Speed * Math.Sin(directionInRadians));
                }
            }

            // Генерация частиц
            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < 500) // Пока частиц меньше 500 генерируем новые
                {
                    var particle = new Particle();
                    particle.X = MouseX;
                    particle.Y = MouseY;
                    particles.Add(particle);
                }
                else
                {
                    break; // Если больше 500, не генерируем
                }
            }
        }

        // Рендер изображения
        private void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.White);
                Render(g);
            }

            // Обновление pb
            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
        }
    }
}
