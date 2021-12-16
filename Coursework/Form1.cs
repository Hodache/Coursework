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
        static List<Particle> particles = new List<Particle>(); // Список частиц

        public Form1()
        {
            InitializeComponent();

            // Привязка изображения к pb
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            // Генерация частиц
            for (var i = 0; i < 500; i++) {
                var particle = new Particle();

                particle.X = picDisplay.Width / 2;
                particle.Y = picDisplay.Height / 2;

                particles.Add(particle);
            }
        }

        // Пересчет состояния системы
        private void UpdateState()
        {

        }


        
        private void timer1_Tick(object sender, EventArgs e)
        {

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.White); 
                
                foreach(var particle in particles)
                {
                    particle.Draw(g);
                }
            }

            // Обновление pb
            picDisplay.Invalidate();
        }
    }
}
