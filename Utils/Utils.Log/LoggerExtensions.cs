using System.Diagnostics;

namespace Utils.Log
{
    /// <summary>
    /// Logger Extensions. The using sample: <example>this.Log().Debug("message")</example>
    /// It requires to setup static field <see cref="Factory"/>. 
    /// </summary>
    public static class LoggerExtensions
    {
        /// <summary>
        /// Logger Factory.
        /// </summary>
        private static ILoggerFactory _factory;

        /// <summary>
        /// Default logger. 
        /// </summary>
        private static ILogger _logger;

        static LoggerExtensions()
        {
            Factory = new MoqLogger();
        }

        /// <summary>
        /// Logger factory. Need to set a specific implementation of <see cref="ILoggerFactory"/> to use this extension. 
        /// Example: <example>LoggerExtensions.Factory = new NLogAdapter()</example>
        /// </summary>
        public static ILoggerFactory Factory
        {
            get { return _factory; }
            set
            {
                _factory = value;
                _logger = _factory?.GetLogger();
            }
        }

        /// <summary>
        /// Logger by default.
        /// </summary>
        /// <param name="value">Sender</param>
        /// <returns></returns>
        public static ILogger Log(this object value)
        {
            return _logger;
        }

        /// <summary>
        /// Logger by specific name
        /// </summary>
        /// <param name="value">Sender</param>
        /// <param name="name">Name.</param>
        /// <returns></returns>
        public static ILogger Log(this object value, string name)
        {
            return Factory.GetLogger(name);
        }

    }
}