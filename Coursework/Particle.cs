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
        public float Life;

        public static Random rnd = new Random();

        public Particle()
        {
            Direction = rnd.Next(360);
            Speed = 1 + rnd.Next(10);
            Radius = 2 + rnd.Next(10);
            Life = 20 + rnd.Next(100);
        }

        public void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100); // Коэф. прозрачности

            int alpha = (int)(k * 255); // Значение альфа-канала
            var color = Color.FromArgb(alpha, Color.Black); // Цвет

            var brush = new SolidBrush(color); // Кисть

            // Отрисовка частицы
            g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            brush.Dispose();
        }
    }
}
