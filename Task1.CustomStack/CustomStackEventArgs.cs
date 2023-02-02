namespace Task1.CustomStack
{
    /// <summary>
    /// For additional data about event.
    /// </summary>
    public class CustomStackEventArgs : EventArgs
    {
        /// <summary>
        /// For output data.
        /// </summary>
        public string Message { get; }
        /// <summary>
        /// Create CustomStackEventArgs for output data.
        /// </summary>
        /// <param name="message"></param>
        public CustomStackEventArgs(string message)
        {
            Message = message;
        }
    }
}
