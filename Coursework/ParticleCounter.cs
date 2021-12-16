using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Coursework
{
    public class ParticleCounter : FunctionalCircle
    {
        private int Count = 0;

        public override void Overlap(Particle particle, Emitter emitter)
        {
            emitter.ResetParticle(particle);
            Count++;
        }

        public void Draw(Graphics g)
        {
            var pen = new Pen(Color.White);

            // Отрисовка области
            g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            pen.Dispose();

            // Отображение количества
            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            var font = new Font("Verdana", 10);

            g.DrawString(
                Count.ToString(),
                font,
                new SolidBrush(Color.White),
                X,
                Y,
                stringFormat
            );
        }
    }
}
