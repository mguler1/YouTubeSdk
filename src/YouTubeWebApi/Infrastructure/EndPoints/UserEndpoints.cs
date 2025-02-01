using Microsoft.AspNetCore.Mvc;
using YouTubeCommon.Models.RequestModels;
using YouTubeWebApi.Infrastructure.Services;

namespace YouTubeWebApi.Infrastructure.EndPoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this WebApplication app)
        {
            app.MapGet("/Users/Login", async ([FromServices]UserService userService,[AsParameters]UserLoginnRequestModel request) =>
            {
                var response = await userService.Login(request);
                return response == null ? Results.NoContent() : Results.Ok(response);
            });
        }
    }
}