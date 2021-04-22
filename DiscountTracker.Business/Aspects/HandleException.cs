using System;
using DiscountTracker.Utilities.Logger;
using PostSharp.Aspects;

namespace DiscountTracker.Business.Aspects
{
    public class HandleException:OnMethodBoundaryAspect
    {
        ILogger _logger = new FileLogger();

        public override void OnException(MethodExecutionArgs args)
        {
            var message = $"An error occured while {args.Method.Name} method running. Exception : {args.Exception.StackTrace}";
            _logger.AddLog(message, LogLevel.Error);
        }
    }
}
