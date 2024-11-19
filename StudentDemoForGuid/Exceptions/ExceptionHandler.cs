using Microsoft.AspNetCore.Diagnostics;
using StudentDemoForGuid.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentDemoForGuid.Exceptions
{
    public class ExceptionHandler:IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
            CancellationToken cancellationToken)
        {
            var response = new ErrorResponse();
            if (exception is StudentNotFoundException)
            {
                response.ErrorCode = StatusCodes.Status404NotFound;
                response.ExceptionMessage = exception.Message;
                response.Title = "Wrong Input";
            }
            else if (exception is ValidationException)
            {
                response.ErrorCode = StatusCodes.Status404NotFound;
                response.ExceptionMessage = exception.Message;
                response.Title = "Invalid Input";
            }
            else
            {
                response.ErrorCode = StatusCodes.Status500InternalServerError;
                response.ExceptionMessage = exception.Message;
                response.Title = "Something Went Wrong";
            }
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
