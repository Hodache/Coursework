using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Coursework
{
    public class Particle
    {
        public int Radius; // Радиус частицы
        public float X; // Координата x
        public float Y; // Координата y
        public float SpeedX; // Скорость по X
        public float SpeedY; // Скорость по Y
        public float Life; // Время жизни
        public Color Color = Color.Orange;

        public static Random rnd = new Random();

        public Particle()
        {
            var direction = (double)rnd.Next(360);
            var speed = 1 + rnd.Next(10);

            // Рассчет вектора скорости
            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            Radius = 2 + rnd.Next(10);
            Life = 20 + rnd.Next(100);
        }

        public void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100); // Коэф. прозрачности

            int alpha = (int)(k * 255); // Значение альфа-канала
            var color = Color.FromArgb(alpha, Color); // Цвет

            var brush = new SolidBrush(color); // Кисть

            // Отрисовка частицы
            g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            brush.Dispose();
        }

        public void DrawVector(Graphics g)
        {
            var pen = new Pen(Color.Blue, 2);

            g.DrawLine(pen, X, Y, X + SpeedX, Y + SpeedY);
        }

        public void DrawInfo(Graphics g)
        {
            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            var text = $"X: {X}\nY: {Y}\nLife: {Life}";
            var font = new Font("Verdana", 10);

            var size = g.MeasureString(text, font);

            g.FillRectangle(
                new SolidBrush(Color.FromArgb(120, Color.Gray)),
                X - size.Width / 2,
                Y - size.Height / 2,
                size.Width,
                size.Height
            );

            g.DrawString(
                text,
                font,
                new SolidBrush(Color.White),
                X,
                Y,
                stringFormat
            );
        }
    }
}
