namespace Task1.CustomExceptions
{
    public class LessThenNecessaryException : Exception
    {
        public LessThenNecessaryException(string? paramName) : base(paramName) { }
    }
}
