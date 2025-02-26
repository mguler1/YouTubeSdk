using YouTubeWebApi.Infrastructure.Services;

namespace YouTubeWebApi.Infrastructure.EndPoints
{
    public static class VideosEndpoints
    {
        public static void MapVideosEndpoints(this WebApplication app)
        {
            var videoEndpointGroup = app.MapGroup("/Videos").AddEndpointFilter<UserTokenEndpointsFilter>();

            videoEndpointGroup.MapGet("/{emailAddress}", async (VideoService videoService, string emailAddress) =>
            {
                var response = await videoService.GetVideos(emailAddress);
                return response == null ? Results.NoContent() : Results.Ok(response);
            });
                
        }
    }
}
