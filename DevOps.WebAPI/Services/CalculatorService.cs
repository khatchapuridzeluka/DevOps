namespace DevOps.WebAPI.Services;

public class CalculatorService : ICalculatorService
{
    public double Add(double a, double b) => a + b;

    public double Subtract(double a, double b) => a - b;
}