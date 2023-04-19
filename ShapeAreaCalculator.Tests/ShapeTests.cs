using ShapeAreaCalculator.Shapes;

namespace ShapeAreaCalculator.Tests;

[TestClass]
public class ShapeTests
{
    [TestMethod]
    public void Circle_NotPositiveRadius_ThrowsArgumentOutOfRangeException()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Circle(0));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Circle(-1));
    }

    [TestMethod]
    public void Circle_AreaCalculation_ReturnsCorrectValue()
    {
        double radius = 5;
        var circle = new Circle(radius);
        double square = Math.PI * Math.Pow(radius, 2);
        Assert.AreEqual(square, circle.GetArea());
    }

    [TestMethod]
    public void Triangle_NotPositiveSideValues_ThrowsArgumentOutOfRangeException()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(-1, 1, 1));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(1, -1, 1));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(1, 1, -1));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(-1, -1, -1));
    }

    [TestMethod]
    public void Triangle_CantExist_ThrowsException()
    {
        Assert.ThrowsException<Exception>(() => new Triangle(3, 4, 10));
    }

    [TestMethod]
    public void Triangle_AreaCalculation_ReturnsCorrectValue()
    {
        var triangle = new Triangle(3, 4, 5);
        Assert.AreEqual(6, triangle.GetArea());
    }

    [TestMethod]
    public void Triangle_IsRight_ReturnsTrue()
    {
        var triangle = new Triangle(3, 4, 5);
        Assert.AreEqual(true, triangle.IsRight);
    }

    [TestMethod]
    public void Triangle_IsRight_ReturnsFalse()
    {
        var triangle = new Triangle(3, 4, 6);
        Assert.AreEqual(false, triangle.IsRight);
    }
}
