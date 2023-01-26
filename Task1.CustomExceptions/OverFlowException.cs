namespace Task1.CustomExceptions
{
    public class OverFlowException : Exception
    {
        public OverFlowException(string? paramName): base(paramName) { }
    }
}
