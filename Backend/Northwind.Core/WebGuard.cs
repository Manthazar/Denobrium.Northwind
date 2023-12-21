using System.Diagnostics;

namespace Northwind.Core
{
    /// <summary>
    /// Paramter verification guard, similar to <see cref="Check"/>, but raises exclusively <see cref="ExternalArgumentException"/> so that it can be handled and reflected in proper external request response codes (such as http 404).
    /// </summary>
    public static class WebGuard
    {
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the given argument is null.
        /// </summary>
        /// <exception cref="ArgumentNullException"> if tested value if null.</exception>
        /// <param name="min">The minimum of the int to throw (valid is +1).</param>
        /// <param name="argumentValue">Argument value to test.</param>
        /// <param name="argumentName">Name of the argument being tested.</param>
        [DebuggerStepThrough]
        public static void IsId(int argumentValue, string argumentName)
            => IsBigger(0, argumentValue, argumentName);

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the given argument is null.
        /// </summary>
        /// <exception cref="ArgumentNullException"> if tested value if null.</exception>
        /// <param name="min">The minimum of the int to throw (valid is +1).</param>
        /// <param name="argumentValue">Argument value to test.</param>
        /// <param name="argumentName">Name of the argument being tested.</param>
        [DebuggerStepThrough]
        public static void IsCode(string argumentValue, string argumentName)
            => IsNotNullOrWhiteSpace(argumentValue, argumentName);

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the given argument is null.
        /// </summary>
        /// <exception cref="ArgumentNullException"> if tested value if null.</exception>
        /// <param name="min">The minimum of the int to throw (valid is +1).</param>
        /// <param name="argumentValue">Argument value to test.</param>
        /// <param name="argumentName">Name of the argument being tested.</param>
        [DebuggerStepThrough]
        public static void IsBigger(int min, int argumentValue, string argumentName)
        {
            if (argumentValue <= min) throw new ArgumentOutOfRangeException(argumentName);
        }

        /// <summary>
        /// Throws an exception if the tested string argument is null or the empty string.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if string value is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the string is empty</exception>
        /// <param name="argumentValue">Argument value to check.</param>
        /// <param name="argumentName">Name of argument being checked.</param>
        /// <param name="detailedMessage">The exception message when argumentValue is null.</param>
        /// <exception cref="ArgumentNullException">When argumentValue is null.</exception>
        /// <exception cref="ArgumentException">When argumentValue is empty.</exception>
        [DebuggerStepThrough]
        public static void IsNotNullOrWhiteSpace(string argumentValue,
                                                  string argumentName,
                                                  string detailedMessage = null!)
        {
            if (argumentValue == null) throw new ArgumentNullException(argumentName);
            if (argumentValue.Length == 0) throw new ArgumentException(detailedMessage ?? "The argument is empty.", argumentName);
            if (string.IsNullOrWhiteSpace(argumentValue)) throw new ArgumentException(detailedMessage ?? "The argument is whitespaces only.", argumentName);
        }
    }
}
