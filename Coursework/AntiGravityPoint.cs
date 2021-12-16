using System;
using System.Collections.Generic;
using System.Text;

namespace Coursework
{
    class AntiGravityPoint : IImpactPoint
    {
        public int Power = 200; // Сила отталкивания

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            float r2 = (float)Math.Max(100, gX * gX + gY * gY);

            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + particle.Radius < Power)
            {
                particle.SpeedX -= gX * Power / r2;
                particle.SpeedY -= gY * Power / r2;
            }
        }
    }
}
