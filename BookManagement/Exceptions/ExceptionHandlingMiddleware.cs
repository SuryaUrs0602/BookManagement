
using System.Net;

namespace BookManagement.Exceptions
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }

            catch (DomainBadRequest ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var errorResponse = new { error = ex.Message };
                await context.Response.WriteAsJsonAsync(errorResponse);
            }

            catch (DomainNotFound ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                var errorResponse = new { error = ex.Message };
                await context.Response.WriteAsJsonAsync(errorResponse);
            }

            catch (DomainInternalServerError ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var errorResponse = new { error = ex.Message };
                await context.Response.WriteAsJsonAsync(errorResponse);
            }

            catch (DomainUnAuthorizedError ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                var errorResponse = new { error = ex.Message };
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
