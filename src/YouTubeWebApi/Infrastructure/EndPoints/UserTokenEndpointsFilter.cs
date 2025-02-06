
using Microsoft.Extensions.Logging;
using YouTubeWebApi.Infrastructure.Services;

namespace YouTubeWebApi.Infrastructure.EndPoints
{
    public class UserTokenEndpointsFilter(UserService userService, ILogger<UserTokenEndpointsFilter> logger) : IEndpointFilter
    {
        public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var token = context.HttpContext.Request.Headers.TryGetValue("UserToken", out var userToken);
            if (!token || string.IsNullOrEmpty(userToken))
            {
                logger.LogWarning("User token not found");
                return Results.Unauthorized();
            }
            var validated = await userService.ValidateUserToken(userToken);
            if (validated is false)
            {
                logger.LogWarning("User token could not be validated");
                return Results.Unauthorized();
            }
            return await next(context);
        }
    }


    //global 
    public static class EndpointMiddleware
    {
        public static void MapUserTokenMiddleware(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path=="/Login")
                {
                    await next();
                    return;
                }
               var userService = context.RequestServices.GetRequiredService<UserService>();
                var token = context.Request.Headers.TryGetValue("UserToken", out var userToken);
                if (!token || string.IsNullOrEmpty(userToken))
                {
                    context.Response.StatusCode = 401;
                    return;
                }
                var validated = await userService.ValidateUserToken(userToken);
                if (validated is false)
                {
                    context.Response.StatusCode = 401;

                    return;
                }
                await next();
            });
        }
    }
}
