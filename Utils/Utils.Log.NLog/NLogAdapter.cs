using System;
using NLog;

namespace Utils.Log.NLog
{
    public class NLogAdapter: ILogger
    {
        private readonly global::NLog.Logger _logger;

        public NLogAdapter(Logger logger)
        {
            _logger = logger;
        }

        public void Flush()
        {
            LogManager.Flush();
        }

        public void Trace(string message)
        {
            _logger.Trace(message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warning(string message)
        {
            _logger.Warn(message);
        }

        public void Warning(Exception exception, string message)
        {
            _logger.Warn(exception, message);
        }

        public void Error(string message)
        {

            _logger.Error(message);
        }

        public void Error(Exception exception)
        {

            _logger.Error(exception);
        }

        public void Error(Exception exception, string message)
        {

            _logger.Error(exception, message);
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public void Fatal(Exception exception)
        {
            _logger.Fatal(exception);
        }

        public void Fatal(Exception exception, string message)
        {
            _logger.Fatal(exception, message);
        }
    }
}
