using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Coursework
{
    public class Emitter
    {
        List<Particle> particles = new List<Particle>(); // Список частиц
        public IImpactPoint impactPoint = null;
        public List<ParticleCounter> counters = new List<ParticleCounter>();
        public ColoringCircle ColoringCircle = new ColoringCircle {
            X = 0,
            Y = 200,
            Radius = 50
        };

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
        public Color DefaultColor = Color.Orange;

        public float GravitationX = 0;
        public float GravitationY = 1;

        public bool vectorsMode;

        public int MouseX = 0;
        public int MouseY = 0;

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

            particle.Color = DefaultColor;
        }

        // Пересчет состояния системы
        public void UpdateState(Graphics g)
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
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    if (impactPoint != null)
                    {
                        impactPoint.ImpactParticle(particle);
                    }
                }

                if (ColoringCircle.Overlaps(particle, g))
                {
                    ColoringCircle.Overlap(particle, this);
                }
            }

            // Изменение состояния счетчиков
            foreach (var counter in counters)
            {
                foreach (var particle in particles)
                {
                    if (counter.Overlaps(particle, g))
                    {
                        counter.Overlap(particle, this);
                    }
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


                if (TouchesMouse(particle, g))
                {
                    particle.DrawInfo(g);
                }
            }

            // Отрисовка счетчиков
            foreach (var counter in counters)
            {
                counter.Draw(g);
            }
            
            // Отрисовка окрашивающей области
            ColoringCircle.Draw(g);
        }

        public bool TouchesMouse(Particle particle, Graphics g)
        {
            Point point = new Point(MouseX, MouseY);

            GraphicsPath particlePath = new GraphicsPath();
            particlePath.AddEllipse(particle.X - particle.Radius, particle.Y - particle.Radius, particle.Radius * 2, particle.Radius * 2);
            Region particleRegion = new Region(particlePath);

            return particleRegion.IsVisible(point, g);
        }
    }
}
