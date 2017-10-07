using NLog;
using NLog.Config;
using NLog.Targets;

namespace Utils.Log.NLog
{
    public class NLogAdapterFactory : ILoggerFactory
    {
        public NLogAdapterFactory (bool defaulConfig)
        {
            if (defaulConfig)
                Configuration();
        }

        public ILogger GetLogger(string name)
        {
            var logger = LogManager.GetLogger(name);
            return new NLogAdapter(logger);
        }

        public ILogger GetLogger()
        {
            var logger = LogManager.GetCurrentClassLogger();
            return new NLogAdapter(logger);
        }

        private static void Configuration()
        {
            // Step 1. Create configuration object 
            var config = new LoggingConfiguration();

            // Step 2. Create targets and add them to the configuration 
            var consoleTarget = new ColoredConsoleTarget();
            consoleTarget.UseDefaultRowHighlightingRules = true;
            config.AddTarget("console", consoleTarget);

            var debugFileTarget = new FileTarget();
            config.AddTarget("file_debug", debugFileTarget);
            var detailedFileTarget = new FileTarget();
            config.AddTarget("file_all", detailedFileTarget);
            var errorsFileTarget = new FileTarget();
            config.AddTarget("file_errors", detailedFileTarget);

            // Step 3. Set target properties 
            consoleTarget.Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}";

            detailedFileTarget.FileName = "${basedir}/!log_all.txt";
            detailedFileTarget.Layout = @"${date:format=HH\:mm\:ss} [${level}]: ${message} ";

            debugFileTarget.FileName = "${basedir}/!log_debug.txt";
            debugFileTarget.Layout = @"${date:format=HH\:mm\:ss} [${level}]: ${message} ";

            errorsFileTarget.FileName = "${basedir}/!log_errors.txt";
            errorsFileTarget.Layout = @"${date:format=HH\:mm\:ss} [${level}]: ${message} : ${exception}";

            // Step 4. Define rules
            var rule1 = new LoggingRule("*", LogLevel.Debug, consoleTarget);
            config.LoggingRules.Add(rule1);

            var rule2 = new LoggingRule("*", LogLevel.Trace, detailedFileTarget);
            config.LoggingRules.Add(rule2);

            var rule3 = new LoggingRule("*", LogLevel.Warn, errorsFileTarget);
            config.LoggingRules.Add(rule3);

            var rule4 = new LoggingRule("*", LogLevel.Debug, debugFileTarget);
            config.LoggingRules.Add(rule4);

            // Step 5. Activate the configuration
            LogManager.Configuration = config;
        }
    }
}