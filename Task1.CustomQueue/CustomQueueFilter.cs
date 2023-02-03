namespace Task1.CustomQueue
{
    /// <summary>
    /// Filter for the remainder of the division .
    /// </summary>
    public static class CustomQueueFilter
    {
        /// <summary>
        /// Filter for the remainder of the division from 4.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="itemLength"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<int> Filter(this IEnumerable<int> source, int itemLength)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Where(i => i % 4 == itemLength);
        }
    }
}
