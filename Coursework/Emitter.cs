using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Coursework
{
    public class Emitter
    {
        List<Particle> particles = new List<Particle>(); // Список частиц
        public IImpactPoint impactPoint = new AntiGravityPoint();

        public int X = 0;
        public int Y = 0;
        private int ParticlesCount = 500; // Кол-во частиц
        private int Direction = 0; // Направление
        private int Spreading = 360; // Разброс частиц
        private int SpeedMin = 1;
        private int SpeedMax = 10;
        private int RadiusMin = 4;
        private int RadiusMax = 15;
        public int LifeMin = 20;
        public int LifeMax = 100;

        public float GravitationX = 0;
        public float GravitationY = 1;

        public bool vectorsMode;


        // Сброс частицы
        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = Particle.rnd.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction + (double)Particle.rnd.Next(Spreading) - Spreading / 2;
            var speed = Particle.rnd.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rnd.Next(RadiusMin, RadiusMax);
        }

        // Пересчет состояния системы
        public void UpdateState()
        {
            // Пересчет свойств частиц
            foreach (var particle in particles)
            {
                particle.Life--;
                if (particle.Life <= 0)
                {
                    ResetParticle(particle);
                }
                else
                {
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    impactPoint.ImpactParticle(particle);

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
                    ResetParticle(particle);
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

                if (vectorsMode)
                {
                    particle.DrawVector(g);
                } 
            }
        }
    }
}
