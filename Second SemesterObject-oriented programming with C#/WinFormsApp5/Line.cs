using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;



namespace WinFormsApp5
{
    public class Line : Figure
    {
        private Point end;
        
        public Line(Point start, Point end, Color color)
        {
            Position = start;
            this.end = end;
            Color = color;
        }

        public override void Draw(Graphics graphics)
        {
            using (Pen pen = new Pen(Color))
            {
                graphics.DrawLine(pen, Position, end);
            }
        }

        public override bool IsPointInside(Point point)
        {
            
            double lineLength = Math.Sqrt(Math.Pow(end.X - Position.X, 2) + Math.Pow(end.Y - Position.Y, 2));
            double distanceFromStart = Math.Sqrt(Math.Pow(point.X - Position.X, 2) + Math.Pow(point.Y - Position.Y, 2));
            double distanceFromEnd = Math.Sqrt(Math.Pow(point.X - end.X, 2) + Math.Pow(point.Y - end.Y, 2));

            
            return Math.Abs(distanceFromStart + distanceFromEnd - lineLength) < 0.001; 
        }
       

        public double Length()
        {
            return Math.Sqrt(Math.Pow(end.X - Position.X, 2) + Math.Pow(end.Y - Position.Y, 2));
        }

       
    }
}
