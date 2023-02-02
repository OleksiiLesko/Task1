namespace Task1.CustomLinkedList
{
    /// <summary>
    /// For additional data about event.
    /// </summary>
    public class CustomLinkedListEventArgs : EventArgs
    {
        /// <summary>
        /// For output data.
        /// </summary>
        public string Message { get; }
        /// <summary>
        /// Create CustomLinkedListEventArgs for output data.
        /// </summary>
        /// <param name="message"></param>
        public CustomLinkedListEventArgs(string message)
        {
            Message = message;
        }
    }
}
