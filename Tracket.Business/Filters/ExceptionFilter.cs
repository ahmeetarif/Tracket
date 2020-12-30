using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Tracket.Common.Exceptions;

namespace Tracket.Business.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        private readonly IStringLocalizer<ExceptionFilter> _localizer;
        public ExceptionFilter(IStringLocalizer<ExceptionFilter> localizer)
        {
            _localizer = localizer;

            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(TracketBadRequestException), HandleBadRequestException },
                { typeof(TracketInternalServerException), HandleInternalServerException },
                { typeof(TracketNotFoundException), HandleNotFoundException }
            };

        }

        public override void OnException(ExceptionContext context)
        {
            HandleExceptions(context);
            base.OnException(context);
        }

        #region Private Functions

        private void HandleExceptions(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            var details = new ValidationProblemDetails(context.ModelState)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = _localizer["InternalServerExceptionTitle"],
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

        private void HandleBadRequestException(ExceptionContext context)
        {
            var exception = context.Exception as TracketBadRequestException;

            var details = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = _localizer["BadRequestExceptionTitle"],
                Detail = exception.Message
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as TracketNotFoundException;

            var details = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = _localizer["NotFoundExceptionTitle"],
                Detail = exception.Message
            };

            context.Result = new NotFoundObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void HandleInternalServerException(ExceptionContext context)
        {
            var exception = context.Exception as TracketInternalServerException;

            var details = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = _localizer["InternalServerExceptionTitle"],
                Detail = exception.Message
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }



        #endregion
    }
}
