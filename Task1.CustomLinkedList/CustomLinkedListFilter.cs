namespace Task1.CustomLinkedList
{
    /// <summary>
    ///  Filter for  the number must be 2 times the number entered.
    /// </summary>
    public static class CustomLinkedListFilter
    {
        /// <summary>
        ///  Filter for  the number must be 2 times the number entered.
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
            return source.Where(i => i * 4 == itemLength);
        }
    }
}
