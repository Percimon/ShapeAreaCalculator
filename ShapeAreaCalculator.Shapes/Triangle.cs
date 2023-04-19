using System;
namespace ShapeAreaCalculator.Shapes
{
    public class Triangle : Shape
    {
        /// <summary>
        /// Стороны треугольника.
        /// При необходимости, можно сделать свойства публичными,
        /// но тогда нужно обязательно проводить проверки на корректные значения в сеттере
        /// и написать соответствующие тесты
        /// </summary>
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        /// <summary>
        /// Является ли треугольник прямоугольным
        /// </summary>
        public bool IsRight { get; private set; }

        ///<exception cref="ArgumentOutOfRangeException"></exception>
        ///<exception cref="Exception"></exception>
        public Triangle(double a, double b, double c)
        {
            if (!CheckTriangleSideValues(ref a, ref b, ref c))
            {
                throw new ArgumentOutOfRangeException("Triangle sides must have correct values");
            }

            SideA = a;
            SideB = b;
            SideC = c;

            if (!CheckIfTriangleCanExist())
            {
                throw new Exception($"Тriangle with sides {SideA}, {SideB}, {SideC} cant exist.");
            }

            CheckIfTriangleIsRight();
        }

        /// <summary>
        /// Проверка величин сторон треугольника - должны быть положительными числами.
        /// возвращает true, если проверка пройдена
        /// </summary>
        private bool CheckTriangleSideValues(ref double a, ref double b, ref double c)
            => a > 0 && b > 0 && c > 0;

        /// <summary>
        /// Проверка существования треугольника
        /// возвращает true, если проверка пройдена
        /// </summary>
        private bool CheckIfTriangleCanExist()
            => (SideA + SideB > SideC) &&
            (SideC + SideB > SideA) &&
            (SideA + SideC > SideB);

        /// <summary>
        /// Проверка, является ли треугольник прямоугольным через теорему Пифагора
        /// </summary>
        private void CheckIfTriangleIsRight()
        {
            var sides = new[] { SideA, SideB, SideC };
            Array.Sort(sides);

            if (Math.Pow(sides[2], 2) == Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2))
                IsRight = true;
            else
                IsRight = false;
        }

        /// <summary>
        /// Подсчет площади круга через радиус по стандартной формуле из геометрии
        /// </summary>
        public override double GetArea()
        {
            double perimeterHalf = 0.5 * (SideA + SideB + SideC);
            return Math.Sqrt(perimeterHalf * (perimeterHalf - SideA) * (perimeterHalf - SideB) * (perimeterHalf - SideC));
        }

    }
}

