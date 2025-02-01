using Microsoft.EntityFrameworkCore;
using YouTubeCommon.Models.ResponseModel;
using YouTubeWebApi.Infrastructure.Context;

namespace YouTubeWebApi.Infrastructure.Services
{
    public class VideoService(YouTubeDbContext dbContext)
    {
        public async Task<List<UserVideosResponseModel>> GetVideos(string emaiLAddress)
        {
           var videos =  dbContext.Videos.Where(x => x.UserId == emaiLAddress)
                .Select(x=>new UserVideosResponseModel
           { 
                   VideoId=x.Id,
                   VideoTitle = x.Title,
                    VideoDescription = x.Description,
                    ThumbnailUrl = x.ThumbnailUrl,
                    VideoUrl = x.VideoUrl,
                    UserEmailAddress = x.UserId,
                    CreateAt = x.CreatedAt
                });
            return await videos.ToListAsync();
        }
    }
}
