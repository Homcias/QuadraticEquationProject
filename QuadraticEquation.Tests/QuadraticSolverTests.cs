// QuadraticEquation.Tests/QuadraticSolverTests.cs
using Xunit;

namespace QuadraticEquation.Tests
{
    public class QuadraticSolverTests
    {
        private readonly QuadraticSolver _solver;
        private const double Precision = 0.0001;

        public QuadraticSolverTests()
        {
            _solver = new QuadraticSolver();
        }

        [Fact]
        public void Solve_WhenAIsZero_ThrowsArgumentException()
        {
            // Arrange
            double a = 0, b = 2, c = 1;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _solver.Solve(a, b, c));
        }

        [Theory]
        [InlineData(1, -5, 6, 2, 2, 3)]  // x^2 - 5x + 6 = 0
        [InlineData(1, 2, -3, 2, -3, 1)]  // x^2 + 2x - 3 = 0
        [InlineData(2, -7, 3, 2, 3, 0.5)] // 2x^2 - 7x + 3 = 0
        public void Solve_WhenDeltaPositive_ReturnsTwoRoots(
            double a, double b, double c,
            int expectedRootCount, double expectedX1, double expectedX2)
        {
            // Act
            var result = _solver.Solve(a, b, c);

            // Assert
            Assert.Equal(expectedRootCount, result.RootCount);
            Assert.InRange(result.X1!.Value, expectedX1 - Precision, expectedX1 + Precision);
            Assert.InRange(result.X2!.Value, expectedX2 - Precision, expectedX2 + Precision);
        }

        [Theory]
        [InlineData(1, 2, 1, 1, -1)]     // x^2 + 2x + 1 = 0
        [InlineData(1, -4, 4, 1, 2)]     // x^2 - 4x + 4 = 0
        [InlineData(2, -12, 18, 1, 3)]   // 2x^2 - 12x + 18 = 0
        public void Solve_WhenDeltaZero_ReturnsOneRoot(
            double a, double b, double c,
            int expectedRootCount, double expectedX)
        {
            // Act
            var result = _solver.Solve(a, b, c);

            // Assert
            Assert.Equal(expectedRootCount, result.RootCount);
            Assert.InRange(result.X1!.Value, expectedX - Precision, expectedX + Precision);
            Assert.Null(result.X2);
        }

        [Theory]
        [InlineData(1, 1, 1)]      // x^2 + x + 1 = 0
        [InlineData(2, 2, 3)]      // 2x^2 + 2x + 3 = 0
        [InlineData(1, -2, 5)]     // x^2 - 2x + 5 = 0
        public void Solve_WhenDeltaNegative_ReturnsNoRoots(double a, double b, double c)
        {
            // Act
            var result = _solver.Solve(a, b, c);

            // Assert
            Assert.Equal(0, result.RootCount);
            Assert.Null(result.X1);
            Assert.Null(result.X2);
        }
    }
}