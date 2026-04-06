using System;

namespace PR4aksenova
{
    /// <summary>
    /// Набор математических функций из ПР4, выделенных для повторного использования и тестирования.
    /// </summary>
    public static class MathFunctions
    {
        /// <summary>
        /// Варианты функции <c>f(x)</c> для расчёта на странице 2.
        /// </summary>
        public enum FxKind
        {
            /// <summary>Гиперболический синус: <c>sinh(x)</c>.</summary>
            Sinh = 0,
            /// <summary>Квадрат: <c>x^2</c>.</summary>
            Square = 1,
            /// <summary>Экспонента: <c>e^x</c>.</summary>
            Exp = 2
        }

        /// <summary>
        /// Вычисляет значение выражения для страницы 1.
        /// </summary>
        /// <param name="x">Значение X (должно быть \(x \ge 1\)).</param>
        /// <param name="y">Значение Y (должно быть \(y \ge 0\)).</param>
        /// <param name="z">Значение Z (в радианах).</param>
        /// <returns>Результат вычисления.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Если нарушены ограничения области допустимых значений.</exception>
        public static double CalculatePage1(double x, double y, double z)
        {
            if (y < 0)
                throw new ArgumentOutOfRangeException(nameof(y), "Y не может быть отрицательным (корень из отрицательного числа).");
            if (x - 1 < 0)
                throw new ArgumentOutOfRangeException(nameof(x), "X должен быть ≥ 1 (корень из x-1).");
            if (x == y)
                throw new ArgumentOutOfRangeException(nameof(x), "X не должен быть равен Y (деление на 0).");

            double numerator = Math.Sqrt(y) + Math.Sqrt(x - 1);
            double denominator = Math.Pow(4 * Math.Abs(x - y), 1.0 / 3.0);
            double trigPart = Math.Pow(Math.Sin(z), 2) + Math.Tan(z);

            return (numerator / denominator) * trigPart;
        }

        /// <summary>
        /// Вычисляет значение выражения для страницы 2.
        /// </summary>
        /// <param name="x">Значение X.</param>
        /// <param name="y">Значение Y.</param>
        /// <param name="fxKind">Выбор функции <c>f(x)</c>.</param>
        /// <returns>Результат вычисления.</returns>
        public static double CalculatePage2(double x, double y, FxKind fxKind)
        {
            double fx;
            switch (fxKind)
            {
                case FxKind.Sinh:
                    fx = Math.Sinh(x);
                    break;
                case FxKind.Square:
                    fx = Math.Pow(x, 2);
                    break;
                case FxKind.Exp:
                    fx = Math.Exp(x);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(fxKind));
            }

            if (x - y == 0)
                return Math.Pow(fx, 2) + Math.Pow(y, 2) + Math.Sin(y);
            if (x - y > 0)
                return Math.Pow(fx - y, 2) + Math.Cos(y);

            return Math.Pow(y - fx, 2) + Math.Tan(y);
        }

        /// <summary>
        /// Вычисляет значение \(y(x)\) для страницы 3 при фиксированном параметре \(b\).
        /// </summary>
        /// <param name="x">Аргумент X.</param>
        /// <param name="b">Параметр B.</param>
        /// <returns>Значение функции.</returns>
        /// <exception cref="ArgumentException">Если выражение не определено (например, \(x=b\) или знаменатель равен 0).</exception>
        public static double CalculatePage3(double x, double b)
        {
            if (x == b)
                throw new ArgumentException("x не должен быть равен b (ln(0)).", nameof(x));

            double numerator = Math.Sqrt(Math.Abs(x - b));
            double denominator = Math.Pow(Math.Abs(Math.Pow(b, 3) - Math.Pow(x, 3)), 1.5);

            if (denominator == 0)
                throw new ArgumentException("Знаменатель равен 0.", nameof(x));

            return numerator / denominator + Math.Log(Math.Abs(x - b));
        }
    }
}
