namespace Task1.CustomStack
{
    /// <summary>
    /// 
    /// </summary>
    public static class CustomStackFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
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
