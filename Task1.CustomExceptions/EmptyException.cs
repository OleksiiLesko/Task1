namespace Task1.CustomExceptions
{
    /// <summary>
    /// Exception for empty container.
    /// </summary>
    public class EmptyException : Exception
    {
        /// <summary>
        /// Create EmptyException for output data.
        /// </summary>
        /// <param name="paramName"></param>
        public EmptyException(string? paramName) : base(paramName) { }
    }
}
