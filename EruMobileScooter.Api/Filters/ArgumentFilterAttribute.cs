using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace EruMobileScooter.Api.Filters
{
    public class ArgumentFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger logger;
        public ArgumentFilterAttribute(ILogger logger)
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context){
              logger.LogError(context.Exception.Message);  
        }
    }
}