namespace ShapeAreaCalculator.Shapes;
/// <summary>
/// Используем абстрактный класс, а не интерфейс,
/// т.к. речь идет об общей сущности, а не каком-то общем функционале
/// </summary>
public abstract class Shape
{
    public abstract double GetArea();
}

