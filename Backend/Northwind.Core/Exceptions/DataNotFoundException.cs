namespace Northwind.Core.Exceptions
{
    /// <summary>
    /// An exception which is thrown in cases when a data item is unexpectedly not found.
    /// </summary>
    public class DataNotFoundException : Exception
    {
        private DataNotFoundException (string message) : base (message)
        {
        }

        public static DataNotFoundException NewForId<T>(int id)
            => new DataNotFoundException($"The object '{nameof(T)}' was not found by the provided id={id}");
    }
}
