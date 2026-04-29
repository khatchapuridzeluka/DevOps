using DevOps.WebAPI.Services;
using Xunit;
using Assert = Xunit.Assert;

namespace TestProject1;

public class CalculatorServiceTests
{
    private readonly CalculatorService _sut = new();

    [Fact]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        var result = _sut.Add(2, 3);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Subtract_LargerMinusSmaller_ReturnsPositive()
    {
        var result = _sut.Subtract(10, 4);
        Assert.Equal(6, result);
    }

    [Xunit.Theory]
    [InlineData(-5, -3, -8)]
    [InlineData(0, 0, 0)]
    [InlineData(1.5, 2.5, 4)]
    public void Add_VariousInputs_ReturnsExpectedSum(double a, double b, double expected)
    {
        var result = _sut.Add(a, b);
        Assert.Equal(expected, result);
    }
}