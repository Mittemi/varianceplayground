using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cocontravariance
{
    public class Shape
    {
        public virtual IColoredShape<Shape> Paint(string color) =>
            new ColoredShape<Shape>() {Shape = this, Color = color};

        public virtual ColoredShape<Shape> InvariantPaint(string color) =>
            new ColoredShape<Shape> {Shape = this, Color = color};
    }

    public class Rectangle : Shape
    {
        // co-variant return type
        public override IColoredShape<Rectangle> Paint(string color)
        {
            return new ColoredShape<Rectangle>() {Color = color, Shape = this};
        }

        //public override ColoredShape<Rectangle> InvariantPaint(string color)
        //{
        //    return new ColoredShape<Rectangle>() { Color = color, Shape = this };
        //}
    }

    public class Cube : Shape
    {
    }
}