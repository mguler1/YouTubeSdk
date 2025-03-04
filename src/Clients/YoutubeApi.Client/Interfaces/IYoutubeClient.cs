using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeCommon.Models.RequestModels;
using YouTubeCommon.Models.ResponseModel;

namespace YoutubeApi.Client.Interfaces
{
    public interface IYoutubeClient
    {
        Task<UserLoginResponseModel> Login(string username, string password);
        Task<UserLoginResponseModel> Login(UserLoginnRequestModel request);
        Task<List<UserVideosResponseModel>> GetVideos(string emailAddress);
    }
}
