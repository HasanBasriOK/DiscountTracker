using System;
using System.IO;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace DiscountTracker.Utilities.Logger
{
    public class FileLogger:ILogger
    {
        private readonly ILog _logger;

        public FileLogger()
        {
            string loggerName = "MyLogger";
            string logFolderPath = Path.GetTempPath();
            string loggerFileName = logFolderPath + "\\ApplicationLogs\\Logfile.log";
            //string loggerFileName = @"D:\Log\Logfile.log";
            string loggerConversionPattern = "%date %level : %message%newline";
            int loggerMaxSizeRollBackups = 40;
            string loggerDatePattern = "yyyy.MM.dd'.log'";
            string loggerMaximumFileSize = "50MB";
            _logger = GetLogger(loggerName, loggerFileName, loggerConversionPattern, loggerMaxSizeRollBackups, loggerDatePattern, loggerMaximumFileSize);
        }

        public static ILog GetLogger(string loggerName, string logFile, string conversionPattern, int maxSizeRollBackups, string datePattern, string maximumFileSize)
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            hierarchy.Threshold = Level.All;

            var loggerA = hierarchy.LoggerFactory.CreateLogger(hierarchy, loggerName);
            loggerA.Hierarchy = hierarchy;
            loggerA.AddAppender(CreateFileAppender(loggerName, logFile, conversionPattern, maxSizeRollBackups, datePattern, maximumFileSize));
            loggerA.Repository.Configured = true;
            loggerA.Level = Level.Debug;

            ILog logA = new LogImpl(loggerA);

            return logA;
        }

        private static IAppender CreateFileAppender(string name, string fileName, string conversionPattern, int maxSizeRollBackups, string datePattern, string maximumFileSize)
        {
            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = conversionPattern;
            patternLayout.ActivateOptions();

            RollingFileAppender appender = new RollingFileAppender();
            appender.Name = name;
            appender.File = fileName;
            appender.AppendToFile = true;
            appender.MaxSizeRollBackups = maxSizeRollBackups;
            appender.DatePattern = datePattern;
            appender.RollingStyle = RollingFileAppender.RollingMode.Composite;
            appender.MaximumFileSize = maximumFileSize;
            appender.Layout = patternLayout;
            appender.LockingModel = new FileAppender.MinimalLock();
            appender.StaticLogFileName = false;
            appender.ActivateOptions();
            return appender;
        }

     

        public void AddLog(string _logMessage, LogLevel _logLevel)
        {
            switch (_logLevel)
            {
                case LogLevel.Fatal:
                    _logger.Fatal(_logMessage);
                    break;
                case LogLevel.Error:
                    _logger.Error(_logMessage);
                    break;
                case LogLevel.Warn:
                    _logger.Warn(_logMessage);
                    break;
                case LogLevel.Info:
                    _logger.Info(_logMessage);
                    break;
                case LogLevel.Debug:
                    _logger.Debug(_logMessage);
                    break;
                default:
                    break;
            }
        }
    }
}
