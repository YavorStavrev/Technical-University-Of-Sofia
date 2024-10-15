using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WinFormsApp5
{
    public class Circle : Figure
    {
        private int radius;

        public Circle(Point position, int radius, Color color)
        {
            Position = position;
            this.radius = radius;
            Color = color;
        }
        
        public override void Draw(Graphics graphics)
        {
            using (SolidBrush brush = new SolidBrush(Color))
            {
                graphics.FillEllipse(brush, Position.X - radius, Position.Y - radius, radius * 2, radius * 2);
            }
        }

        public override bool IsPointInside(Point point)
        {
            return (Math.Pow(point.X - Position.X, 2) + Math.Pow(point.Y - Position.Y, 2)) <= Math.Pow(radius, 2);
        }
       
    }
}
