using System;
using System.Text;

namespace GoodNoteEditor.WebUI.Infrastructure.Extensions
{
    /// <summary>
    /// Our own Extension for exceptions 
    /// </summary>
    public static class ExceptionExtension
    {
        /// <summary>
        /// Exception Wide Info 
        /// </summary>
        /// <param name="exc">exception</param>
        /// <param name="source">source</param>
        /// <returns>info</returns>
        public static StringBuilder WideInfo(this Exception exc, string source)
        {
            // Create the string builder for append log
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"********** {DateTime.Now} **********");
            if (exc.InnerException != null)
            {
                builder.Append("Inner Exception Type: ");
                builder.AppendLine(exc.InnerException.GetType().ToString());
                builder.Append("Inner Exception: ");
                builder.AppendLine(exc.InnerException.Message);
                builder.Append("Inner Source: ");
                builder.AppendLine(exc.InnerException.Source);
                if (exc.InnerException.StackTrace != null)
                {
                    builder.AppendLine("Inner Stack Trace: ");
                    builder.AppendLine(exc.InnerException.StackTrace);
                }
            }
            builder.Append("Exception Type: ");
            builder.AppendLine(exc.GetType().ToString());
            builder.AppendLine("Exception: " + exc.Message);
            builder.AppendLine("Source: " + source);
            builder.AppendLine("Stack Trace: ");
            if (exc.StackTrace != null)
            {
                builder.AppendLine(exc.StackTrace);
                builder.AppendLine();
            }

            return builder;
        }
    }
}