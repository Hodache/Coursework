using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Coursework
{
    class Particle
    {
        public int Radius; // Радиус частицы
        public float X; // Координата x
        public float Y; // Координата y
        public float Direction; // Направление движения в градусах
        public float Speed; // Скорость перемещения

        public static Random rnd = new Random();

        public Particle()
        {
            Direction = rnd.Next(360);
            Speed = 1 + rnd.Next(10);
            Radius = 2 + rnd.Next(10);
        }

        public void Draw(Graphics g)
        {
            var brush = new SolidBrush(Color.Black); // Кисть

            // Отрисовка частицы
            g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            brush.Dispose();
        }
    }
}
