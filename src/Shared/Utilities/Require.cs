using System;

namespace Domainator.Utilities
{
    [AttributeUsage(AttributeTargets.Parameter)]
    internal sealed class ValidatedNotNullAttribute : Attribute
    {
    }

    internal static class Require
    {

        public static void NotNull<T>([ValidatedNotNullAttribute] T paramValue, string paramName) where T : class
        {
            if (paramValue == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void ZeroOrGreater(int value, string param)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(param, value, "Value must be zero or greater.");
            }
        }

        public static void Positive(int value, string param)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(param, value, "Value must be positive.");
            }
        }

        public static void NotEmpty(string paramValue, string paramName)
        {
            False(string.IsNullOrEmpty(paramValue), paramName, "Value must be not empty.");
        }

        public static void NotEmpty(Guid paramValue, string paramName)
        {
            False(paramValue == Guid.Empty, paramName, "Value must be not empty.");
        }

        public static void True(bool condition, string paramName, string message)
        {
            if (!condition)
            {
                throw new ArgumentException(message, paramName);
            }
        }

        public static void False(bool condition, string paramName, string message)
        {
            if (condition)
            {
                throw new ArgumentException(message, paramName);
            }
        }
    }
}
