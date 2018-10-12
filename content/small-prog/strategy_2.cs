using System;
using System.Numerics;

namespace Strategy
{
    public interface IDiscriminantStrategy
    {
        double CalculateDiscriminant(double a, double b, double c);
    }

    public class OrdinaryDiscriminantStrategy : IDiscriminantStrategy
    {
        public double CalculateDiscriminant(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }
    }

    public class RealDiscriminantStrategy : IDiscriminantStrategy
    {
        public double CalculateDiscriminant(double a, double b, double c)
        {
            var discriminant = b * b - 4 * a * c;

            return discriminant < 0 ? double.NaN : discriminant;
        }
    }

    public class QuadraticEquationSolver
    {
        private readonly IDiscriminantStrategy _strategy;

        public QuadraticEquationSolver(IDiscriminantStrategy strategy)
        {
            _strategy = strategy;
        }

        public Tuple<Complex, Complex> Solve(double a, double b, double c)
        {
            var discriminant = _strategy.CalculateDiscriminant(a, b, c);

            Console.WriteLine("discriminant {0}", discriminant);

            var sqrt = Complex.Sqrt(discriminant);

            Console.WriteLine("sqrt discriminant {0}", sqrt);

            return Tuple.Create((-b + sqrt) / 2 / a, (-b - sqrt) / 2 / a);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var qes = new QuadraticEquationSolver(new RealDiscriminantStrategy());
            var result = qes.Solve(1, -1, -2);
            Console.WriteLine(result);
        }
    }
}