namespace Task1.CustomStack
{
    public class CustomStackEventArgs : EventArgs
    {
        public string Message { get; }
        public CustomStackEventArgs(string message)
        {
            Message = message;
        }
    }
}
