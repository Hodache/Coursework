using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Coursework
{
    public abstract class IImpactPoint
    {
        public float X;
        public float Y;

        public abstract void ImpactParticle(Particle particle);
    }
}
