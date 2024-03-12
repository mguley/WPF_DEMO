namespace WPF_Library.Abstractions;

public interface ICalculator
{
    /// <summary>
    /// Adds two double-precision floating-point numbers.
    /// </summary>
    /// <param name="x">The first number to add.</param>
    /// <param name="y">The second number to add.</param>
    /// <returns>The sum of <paramref name="x"/> and <paramref name="y"/>.</returns>
    double Add(double x, double y);

    /// <summary>
    /// Subtracts one double-precision floating-point number from another.
    /// </summary>
    /// <param name="x">The number to be subtracted from.</param>
    /// <param name="y">The number to subtract.</param>
    /// <returns>The difference of <paramref name="x"/> and <paramref name="y"/>.</returns>
    double Subtract(double x, double y);

    /// <summary>
    /// Multiplies two double-precision floating-point numbers.
    /// </summary>
    /// <param name="x">The first number to multiply.</param>
    /// <param name="y">The second number to multiply.</param>
    /// <returns>The product of <paramref name="x"/> and <paramref name="y"/>.</returns>
    double Multiply(double x, double y);

    /// <summary>
    /// Divides one double-precision floating-point number by another.
    /// </summary>
    /// <param name="x">The dividend.</param>
    /// <param name="y">The divisor.</param>
    /// <returns>The quotient of <paramref name="x"/> divided by <paramref name="y"/>.</returns>
    /// <exception cref="System.DivideByZeroException">Thrown when <paramref name="y"/> is 0.</exception>
    double Divide(double x, double y);
}
