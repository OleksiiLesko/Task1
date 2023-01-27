namespace Task1.CustomExceptions
{
    public class EmptyException : Exception
    {
        public EmptyException(string? paramName) : base(paramName) { }
    }
}
