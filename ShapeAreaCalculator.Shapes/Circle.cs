using System;
namespace ShapeAreaCalculator.Shapes
{
    public class Circle : Shape
    {
        /// <summary>
        /// Радиус круга
        /// При необходимости, можно сделать свойство публичным,
        /// но тогда нужно обязательно проводить проверки на корректные значения в сеттере
        /// и написать соответствующие тесты
        /// </summary>
        public double Radius { get; }

        ///<exception cref="ArgumentOutOfRangeException">
        ///Проверка величины радиуса круга - она должна быть положительным числом
        /// </exception>
        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentOutOfRangeException("Circle's radius must be positive.");

            Radius = radius;
        }

        public override double GetArea() => Math.PI * Math.Pow(Radius, 2);
    }
}

