using Maripiell.Common.Common.Domain.Common;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Net;
using System.Resources;

namespace Maripiell.Common.Common.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ResourceManager resourceManager;

        public ExceptionMiddleware(RequestDelegate next, string baseName)
        {
            this.next = next;
            this.resourceManager = new ResourceManager(baseName, typeof(ExceptionMiddleware).Assembly);
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/text";
            string response;
            if (exception is CustomError)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                response = exception.Message;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response = resourceManager.GetString("FailedToProcess", CultureInfo.CurrentUICulture);
            }

            return context.Response.WriteAsync(response);
        }
    }
}
