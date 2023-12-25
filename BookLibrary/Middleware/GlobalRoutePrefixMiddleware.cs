namespace BookLibrary.Middleware;

public class GlobalRoutePrefixMiddleware(RequestDelegate next, string routePrefix)
{
    public async Task InvokeAsync(HttpContext context)
    {
        context.Request.PathBase = new PathString(routePrefix);
        await next(context);
    }
}