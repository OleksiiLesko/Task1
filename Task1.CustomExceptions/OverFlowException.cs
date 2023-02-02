namespace Task1.CustomExceptions
{
    /// <summary>
    /// Exception for over flow elements in container.
    /// </summary>
    public class OverFlowException : Exception
    {
        /// <summary>
        /// Create LessThenNecessaryException for output data.
        /// </summary>
        /// <param name="paramName"></param>
        public OverFlowException(string? paramName): base(paramName) { }
    }
}
