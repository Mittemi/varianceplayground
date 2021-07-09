using System;
using System.Collections.Generic;

namespace cocontravariance
{
    //Read-only Datastructures -> covariant
    //Write-only Datastructures -> contravariant
    //Read/write -> invariant

    public class Sample
    {
        public void DoSomething()
        {
            var multiFactory = new MultiFactory();

            var rectangleFactory = new GenericFactory<Rectangle>(() => new Rectangle());

            var cubeFactory = new GenericFactory<Cube>(() => new Cube());

            multiFactory.InstallFactory(rectangleFactory);
            multiFactory.InstallFactory(cubeFactory);

            //multiFactory.LessPowerfulInstall(rectangleFactor);
            //multiFactory.LessPowerfulInstall(cubeFactory);


            //-------------------------------------------------------------------------------------

            var cubeFactories = new List<IFactory<Cube>> {cubeFactory};

            var rectangleFactories = new List<IFactory<Rectangle>> {rectangleFactory};

            IEnumerable<IFactory<Shape>> factories = rectangleFactories;

            factories = cubeFactories;

            IEnumerable<IFactory<Rectangle>> rectFactEnumerable = rectangleFactories;

            //rectFactEnumerable = cubeFactories;


            foreach (var factory in factories)
            {
                multiFactory.InstallFactory(factory);

                //multiFactory.LessPowerfulInstall(factory);
            }

            //-------------------------------------------------------------------------------------
            {
                foreach (var shape in multiFactory.BuildShapes())
                {
                    IColoredShape<Shape> coloredShape = shape.Paint("SomeColor");
                    coloredShape = shape.InvariantPaint("SomeColor");
                }

                foreach (var factory in rectangleFactories)
                {
                    Rectangle rectangle = factory.Build();

                    IColoredShape<Rectangle> coloredRectangle = rectangle.Paint("SomeColor");

                    IColoredShape<Shape> coloredShape = coloredRectangle;

                    //coloredRectangle = rectangle.InvariantPaint("SomeColor");
                    coloredShape = rectangle.InvariantPaint("SomeColor");
                }

                foreach (IFactory<Shape> factory in rectFactEnumerable)
                {
                    //Rectangle rectangle = factory.Build();
                }
            }
            //------------------------------------------------------------------------------------
            {
                Cube cube = cubeFactory.Build();

                //IColoredShape<Cube> coloredCube = cube.Paint("SomeColor");
                IColoredShape<Shape> coloredShape = cube.Paint("SomeColor");
            }


            //------------------------------------------------------------------------------------
            string[] strings = new string[1];
            object[] array = strings;


            array[0] = 1; // ka-boom
        }
    }
}