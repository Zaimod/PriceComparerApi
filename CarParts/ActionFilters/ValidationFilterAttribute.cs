using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParts.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        private readonly ILoggerManager _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationFilterAttribute"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public ValidationFilterAttribute(ILoggerManager logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Called before the action executes, after model binding is complete.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext" />.</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];

            var param = context.ActionArguments
                .SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;

            if(param == null)
            {
                _logger.LogError($"Object sent from client is null. Controller: {controller}, action: {action}");
                context.Result = new BadRequestObjectResult($"Object is null. Controller: {controller}, action: {action}");

                return;
            }

            if (!context.ModelState.IsValid)
            {
                _logger.LogError($"Invalid model state for the object. Controller: {controller}, action: {action}"); 
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }

        /// <summary>
        /// Called after the action executes, before the action result.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext" />.</param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }    
    }
}
