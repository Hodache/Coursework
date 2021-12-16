using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Coursework
{
    public abstract class FunctionalCircle
    {
        public float X;
        public float Y;
        public int Radius;

        public bool Overlaps(Particle particle, Graphics g)
        {
            // Берем информацию о формах объектов
            var circlePath = new GraphicsPath();
            circlePath.AddEllipse(X - Radius, Y - Radius, Radius * 2, Radius * 2);

            var particlePath = new GraphicsPath();
            particlePath.AddEllipse(particle.X, particle.Y, particle.Radius * 2, particle.Radius * 2);

            // Определяем пересечение
            var region = new Region(circlePath);
            region.Intersect(particlePath);
            return !region.IsEmpty(g);
        }

        public abstract void Overlap(Particle particle, Emitter emitter);
    }
}
