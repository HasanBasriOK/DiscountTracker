using System;
namespace DiscountTracker.Utilities.Logger
{
    public interface ILogger
    {
       void AddLog(string _LogMessage, LogLevel _LogLevel);
    }
}
