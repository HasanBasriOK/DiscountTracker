using System;
using DiscountTracker.Entities.Core;
using DiscountTracker.Entities.MongoDB;
using DiscountTracker.Utilities.Logger;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace DiscountTracker.Business.Aspects
{
    [Serializable]
    public class HandleExceptionAspect:OnMethodBoundaryAspect
    {
        ILogger _logger = new FileLogger();

        public override void OnException(MethodExecutionArgs args)
        {
            var message = $"An error occured while {args.Method.Name} method running. Exception : {args.Exception.StackTrace}";
            _logger.AddLog(message, LogLevel.Error);

            args.ReturnValue = new ErrorResult(message);
            
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            base.OnEntry(args);
            Console.WriteLine("asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasd");
        }

        




    }
}
