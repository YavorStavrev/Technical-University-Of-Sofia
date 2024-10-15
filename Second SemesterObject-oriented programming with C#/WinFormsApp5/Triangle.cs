using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WinFormsApp5
{
    public class Triangle : Figure
    {
        private int sideLength;

        public Triangle(Point position, int sideLength, Color color)
        {
            Position = position;
            this.sideLength = sideLength;
            Color = color;
        }

        public override void Draw(Graphics graphics)
        {
            Point top = new Point(Position.X, Position.Y - sideLength);
            Point left = new Point(Position.X - sideLength / 2, Position.Y + sideLength / 2);
            Point right = new Point(Position.X + sideLength / 2, Position.Y + sideLength / 2);

            Point[] points = { top, left, right };

            using (SolidBrush brush = new SolidBrush(Color))
            {
                graphics.FillPolygon(brush, points);
            }
        }

        public override bool IsPointInside(Point point)
        {
            
            Point top = new Point(Position.X, Position.Y - sideLength);
            Point left = new Point(Position.X - sideLength / 2, Position.Y + sideLength / 2);
            Point right = new Point(Position.X + sideLength / 2, Position.Y + sideLength / 2);

            float area = 0.5f * (-left.Y * right.X + top.Y * (-left.X + right.X) + top.X * (left.Y - right.Y) + left.X * right.Y);
            float s = 1 / (2 * area) * (top.Y * right.X - top.X * right.Y + (right.Y - top.Y) * point.X + (top.X - right.X) * point.Y);
            float t = 1 / (2 * area) * (top.X * left.Y - top.Y * left.X + (top.Y - left.Y) * point.X + (left.X - top.X) * point.Y);

            return s > 0 && t > 0 && 1 - s - t > 0;
        }
        
    }
   
}
