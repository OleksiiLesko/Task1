namespace Task1.CustomQueue
{
    /// <summary>
    /// For additional data about event.
    /// </summary>
    public class CustomQueueEventArgs : EventArgs
    {
        /// <summary>
        /// For output data.
        /// </summary>
        public string Message { get; }
        /// <summary>
        /// Create CustomQueueEventArgs for output data.
        /// </summary>
        /// <param name="message"></param>
        public CustomQueueEventArgs(string message)
        {
            Message = message;
        }
    }
}
