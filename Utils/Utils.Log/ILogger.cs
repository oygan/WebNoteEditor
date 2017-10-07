using System;

namespace Utils.Log
{
    /// <summary>
    /// Defines the interface used by application to report errors.
    /// For the using see <see cref="LoggerExtensions"/>.
    /// </summary>
    public interface ILogger
    {
        /*
            === Logging levels ===
            FATAL - Very serious errors! Any error that is forcing a shutdown of the service or application to prevent data loss (or further data loss)
            ERROR - Error messages - most of the time these are Exceptions. 
                Other runtime errors or unexpected conditions. Expect these to be immediately visible on a status console.
            WARN - Non-critical issues. Use of deprecated APIs, poor use of API, 'almost' errors,
                other runtime situations that are undesirable or unexpected, but not necessarily "wrong". 
                Expect these to be immediately visible on a status console.         
            INFO - User-friendly message for the customer. Interesting runtime events (startup/shutdown). Expect these to be immediately visible on a console, 
                so be conservative and keep to a minimum.         
            DEBUG - Technical information for the developer. Detailed information on the flow through the system. Expect these to be written to logs only.
            TRACE - Very detailed logs. more detailed information. Expect these to be written to logs only.
         */

        /// <summary>
        /// Flush any pending log messages.
        /// </summary>
        void Flush();

        /// <summary>
        /// Very detailed logs. Writes the diagnostic message at the Trace level.
        /// </summary>
        /// <param name="message"></param>
        void Trace(string message);

        /// <summary>
        /// Technical information for the developer. Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="message"></param>
        void Debug(string message);

        /// <summary>
        /// User-friendly message for the customer. Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="message">Log message.</param>
        void Info(string message);

        /// <summary>
        /// Non-critical issues. Writes the diagnostic message at the Warning level.
        /// </summary>
        /// <param name="message">Log message.</param>
        void Warning(string message);

        /// <summary>
        /// Non-critical issues. Writes the diagnostic message at the Warning level.
        /// </summary>
        /// <param name="exception">Exception message.</param>
        /// <param name="message">Log message.</param>
        void Warning(Exception exception, string message);

        /// <summary>
        /// Error messages - most of the time these are Exceptions. Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="message">Log message.</param>
        void Error(string message);

        /// <summary>
        /// Error messages - most of the time these are Exceptions. Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="exception">Exception message.</param>
        void Error(Exception exception);

        /// <summary>
        /// Error messages - most of the time these are Exceptions. Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="exception">Exception message.</param>
        /// <param name="message">Log message.</param>
        void Error(Exception exception, string message);

        /// <summary>
        /// Very serious errors! Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="message">Log message.</param>
        void Fatal(string message);

        /// <summary>
        /// Very serious errors! Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="exception">Exception message.</param>
        void Fatal(Exception exception);

        /// <summary>
        /// Very serious errors! Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="exception">Exception message.</param>
        /// <param name="message">Log message.</param>
        void Fatal(Exception exception, string message);
    }
}
