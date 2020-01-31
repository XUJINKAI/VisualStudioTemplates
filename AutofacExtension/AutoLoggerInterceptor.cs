using Castle.DynamicProxy;
using Serilog;

namespace AutofacApp
{
    public class AutoLoggerInterceptor : IInterceptor
    {
        private readonly ILogger _logger;

        public AutoLoggerInterceptor(ILogger logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            _logger.Information($"Method {invocation.Method.Name} Started.");

            invocation.Proceed();

            _logger.Information($"Method {invocation.Method.Name} Ended.");
        }
    }
}
