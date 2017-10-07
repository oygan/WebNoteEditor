namespace Utils.Log
{
    /// <summary>
    /// Defines the interface used by application to get a logger implementation.
    /// </summary>
    public interface ILoggerFactory
    {
        /// <summary>
        /// Creates or gets default <see cref="ILogger"/> implementation.
        /// </summary>
        /// <returns></returns>
        ILogger GetLogger();

        /// <summary>
        /// Creates <see cref="ILogger"/> implementation.
        /// </summary>
        /// <param name="name">Logger's name</param>
        /// <returns></returns>
        ILogger GetLogger(string name);
    }
}