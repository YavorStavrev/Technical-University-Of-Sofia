using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WinFormsApp5
{
    public abstract class Figure
    {

        public Point Position { get; set; }
        public Color Color { get; set; }

        public abstract void Draw(Graphics graphics);

        public abstract bool IsPointInside(Point point);

        public virtual void Move(Point newPosition)
        {
            Position = newPosition;
        }
       
    }
}
