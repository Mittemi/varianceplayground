using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cocontravariance
{
    // contra variant generic type def
    public interface IItemDestroyer<in TShape>
    {
        void DestroyItem(TShape item);
    }

    // in-variant generic type def
    public interface IItemContainer<TShape>
    {
        void Add(TShape shape);

        TShape GetSomeItem();
    }

    // co variant generic type def
    public interface IFactory<out TShape> where TShape : Shape
    {
        TShape Build();
    }
}