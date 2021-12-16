using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Coursework
{
    class Emitter
    {
        private int ParticlesCount = 500; // Кол-во частиц
        List<Particle> particles = new List<Particle>(); // Список частиц
        public int MouseX = 0;
        public int MouseY = 0;

        public float GravitationX = 0;
        public float GravitationY = 1;

        // Пересчет состояния системы
        public void UpdateState()
        {
            // Пересчет свойств частиц
            foreach (var particle in particles)
            {
                particle.Life--;

                if (particle.Life < 0)
                {
                    particle.Life = 20 + Particle.rnd.Next(100);
                    particle.Radius = 2 + Particle.rnd.Next(10);

                    var direction = (double)Particle.rnd.Next(360);
                    var speed = 1 + Particle.rnd.Next(10);

                    particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
                    particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

                    particle.X = MouseX;
                    particle.Y = MouseY;
                }
                else
                {
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }

            // Генерация частиц
            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < ParticlesCount)
                {
                    var particle = new Particle();
                    particle.X = MouseX;
                    particle.Y = MouseY;
                    particles.Add(particle);
                }
                else
                {
                    break; // Если больше необходимого кол-ва, не генерируем
                }
            }
        }

        // Рендер изображения
        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
                particle.DrawVector(g);
            }
        }
    }
}
