using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WinFormsApp5
{
    public class Rectangle : Figure
    {
        private int width;
        private int height;

        public Rectangle(Point position, int width, int height, Color color)
        {
            Position = position;
            this.width = width;
            this.height = height;
            Color = color;
        }

        public override void Draw(Graphics graphics)
        {
            using (SolidBrush brush = new SolidBrush(Color))
            {
                graphics.FillRectangle(brush, Position.X, Position.Y, width, height);
            }
        }

        public override bool IsPointInside(Point point)
        {
            
            return point.X >= Position.X && point.X <= Position.X + width
                && point.Y >= Position.Y && point.Y <= Position.Y + height;
        }
       
    }
}
