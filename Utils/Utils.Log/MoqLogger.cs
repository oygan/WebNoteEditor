using System;

namespace Utils.Log
{
    /// <summary>
    /// Moq of <see cref="ILoggerFactory"/> and <see cref="ILogger"/>>
    /// </summary>
    public class MoqLogger : ILoggerFactory, ILogger
    {
        public ILogger GetLogger()
        {
            return this;
        }

        public ILogger GetLogger(string name)
        {
            return this;
        }

        public void Flush()
        {
        }

        public void Trace(string message)
        {
        }

        public void Debug(string message)
        {
        }

        public void Info(string message)
        {
        }

        public void Warning(string message)
        {
        }

        public void Warning(Exception exception, string message)
        {
        }

        public void Error(string message)
        {
        }

        public void Error(Exception exception)
        {
        }

        public void Error(Exception exception, string message)
        {
        }

        public void Fatal(string message)
        {
        }

        public void Fatal(Exception exception)
        {
        }

        public void Fatal(Exception exception, string message)
        {
        }
    }
}