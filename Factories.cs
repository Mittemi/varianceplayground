using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cocontravariance
{
    public class MultiFactory
    {
        private readonly List<IFactory<Shape>> _factories = new List<IFactory<Shape>>();

        public void InstallFactory(IFactory<Shape> factory)
        {
            _factories.Add(factory);
        }

        public void LessPowerfulInstall(GenericFactory<Shape> factory)
        {
            _factories.Add(factory);
        }

        public IEnumerable<Shape> BuildShapes()
        {
            foreach (var factory in _factories)
            {
                yield return factory.Build();
            }
        }
    }

    public class GenericFactory<TShape> : IFactory<TShape> where TShape : Shape
    {
        private readonly Func<TShape> _builderFunc;

        public GenericFactory(Func<TShape> builderFunc)
        {
            _builderFunc = builderFunc;
        }

        public TShape Build()
        {
            return _builderFunc();
        }
    }
}