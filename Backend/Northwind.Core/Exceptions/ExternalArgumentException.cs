namespace Northwind.Core.Exceptions
{
    /// <summary>
    /// Represents an argument exception which is raised when the argument is coming from the outside (public/ web request).
    /// </summary>
    /// <remarks>
    /// Indicates that the source of the error is in the request and NOT some internal shebang.
    /// </remarks>
    public class ExternalArgumentException : ArgumentException
    {
        public ExternalArgumentException(string message) : base(message) { }
    }
}
