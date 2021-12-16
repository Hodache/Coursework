using System;
using System.Collections.Generic;
using System.Text;

namespace Coursework
{
    public class TopEmitter : Emitter
    {
        public int Width; // Длина экрана

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle);

            particle.X = Particle.rnd.Next(Width);
            particle.Y = 0;

            particle.SpeedY = 1;
            particle.SpeedX = Particle.rnd.Next(-2, 2);
        }
    }
}
