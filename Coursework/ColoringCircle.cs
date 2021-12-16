using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Coursework
{
    public class ColoringCircle : FunctionalCircle
    {
        public Color NewColor = Color.Green;

        public override void Overlap(Particle particle, Emitter emitter)
        {
            particle.Color = NewColor;
        }

        public void Draw(Graphics g)
        {
            var pen = new Pen(NewColor);

            // Отрисовка области
            g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            pen.Dispose();
        }
    }
}
