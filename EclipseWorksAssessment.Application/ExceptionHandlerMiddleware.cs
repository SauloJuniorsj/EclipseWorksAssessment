using EclipseWorksAssessment.Application.ViewModels;
using EclipseWorksAssessment.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace EclipseWorksAssessment.Application
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainLogicException domainException)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorResponseModel(domainException.Message)));
            }
            catch (Exception exception)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorResponseModel(exception.Message + "\n Verify your logs: " + DateTime.Now.ToString())));
            }
        }
    }
}

