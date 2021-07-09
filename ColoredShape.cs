using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cocontravariance
{
    public class ColoredShape<TShape> : IColoredShape<TShape> where TShape : Shape
    {
        public string Color { get; set; }

        public TShape Shape { get; set; }
    }

    // co variant generic type def
    public interface IColoredShape<out TShape>
    {
        string Color { get; }
        TShape Shape { get; }
    }
}