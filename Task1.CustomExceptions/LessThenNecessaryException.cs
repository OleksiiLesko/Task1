namespace Task1.CustomExceptions
{
    /// <summary>
    /// Exception for less then necessary elements in container.
    /// </summary>
    public class LessThenNecessaryException : Exception
    {
        /// <summary>
        /// Create LessThenNecessaryException for output data.
        /// </summary>
        /// <param name="paramName"></param>
        public LessThenNecessaryException(string? paramName) : base(paramName) { }
    }
}
