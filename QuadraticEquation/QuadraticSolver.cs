// QuadraticEquation/QuadraticSolver.cs
namespace QuadraticEquation
{
    public class QuadraticSolver
    {
        public class QuadraticResult
        {
            public int RootCount { get; set; }
            public double? X1 { get; set; }
            public double? X2 { get; set; }
        }

        public QuadraticResult Solve(double a, double b, double c)
        {
            // Sprawdzenie czy równanie jest kwadratowe
            if (Math.Abs(a) < double.Epsilon)
            {
                throw new ArgumentException("Współczynnik 'a' nie może być równy 0");
            }

            // Obliczenie delty
            double delta = (b * b) - (4 * a * c);

            // Przygotowanie wyniku
            var result = new QuadraticResult();

            if (Math.Abs(delta) < double.Epsilon) // delta = 0
            {
                result.RootCount = 1;
                result.X1 = -b / (2 * a);
                result.X2 = null;
            }
            else if (delta > 0) // delta > 0
            {
                result.RootCount = 2;
                result.X1 = (-b - Math.Sqrt(delta)) / (2 * a);
                result.X2 = (-b + Math.Sqrt(delta)) / (2 * a);
            }
            else // delta < 0
            {
                result.RootCount = 0;
                result.X1 = null;
                result.X2 = null;
            }

            return result;
        }
    }
}