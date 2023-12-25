using System.Net;
using System.Text.Json;
using Contracts;
using Entities.ErrorModel;
using Entities.Exceptions.BadRequest;
using Entities.Exceptions.CQRS;
using Entities.Exceptions.NotFound;
using Microsoft.AspNetCore.Diagnostics;

namespace BookLibrary.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is null)
                    return;

                context.Response.StatusCode = contextFeature.Error switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    BadRequestException => StatusCodes.Status400BadRequest,
                    ValidationAppException => StatusCodes.Status422UnprocessableEntity,
                    _ => StatusCodes.Status500InternalServerError
                };

                logger.LogError($"Something went wrong: {contextFeature.Error}");

                if (contextFeature.Error is ValidationAppException exception)
                {
                    await context.Response
                        .WriteAsync(JsonSerializer.Serialize(new { exception.Errors }));
                }
                else
                {
                    await context.Response.WriteAsync(
                        new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString()
                    );
                }
            });
        });
    }
}