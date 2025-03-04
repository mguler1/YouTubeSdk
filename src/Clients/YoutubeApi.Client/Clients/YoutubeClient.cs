using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using YoutubeApi.Client.Builders;
using YoutubeApi.Client.Extensions;
using YoutubeApi.Client.Interfaces;
using YouTubeCommon.Models.RequestModels;
using YouTubeCommon.Models.ResponseModel;

namespace YoutubeApi.Client.Clients
{
    public class YoutubeClient(HttpClient httpClient) : IYoutubeClient
    {
        public async Task<List<UserVideosResponseModel>> GetVideos(string emailAddress)
        {
            var url=new FluentEndpointBuilder(httpClient.BaseAddress!.ToString())
                .AddRoute("Videos")
                .AddRoute(emailAddress)
                .Build();
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var streamData = await response.Content.ReadAsStreamAsync();
            return JsonSerilaizerUtils.Deserialize<List<UserVideosResponseModel>>(streamData);
        }

        public async Task<UserLoginResponseModel> Login(string email, string password)
        {
            var url = new FluentEndpointBuilder(httpClient.BaseAddress!.ToString())
                 .AddRoute("Users")
                 .AddRoute("Login")
                 .AddParam(nameof(UserLoginnRequestModel.Email), email)
                 .AddParam(nameof(UserLoginnRequestModel.Password), password)
                 .Build();
            var response = await httpClient.GetAsync(url);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Email or Password Incorrect");
            }
            var streamData = await response.Content.ReadAsStreamAsync();
            return JsonSerilaizerUtils.Deserialize<UserLoginResponseModel>(streamData);
        }

        public Task<UserLoginResponseModel> Login(UserLoginnRequestModel request)
        {
            return Login(request.Email!, request.Password!);
        }
    }
}
