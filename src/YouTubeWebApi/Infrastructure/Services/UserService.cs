
using Microsoft.EntityFrameworkCore;
using System;
using YouTubeCommon.Models.RequestModels;
using YouTubeCommon.Models.ResponseModel;
using YouTubeWebApi.Infrastructure.Context;

namespace YouTubeWebApi.Infrastructure.Services
{
    public class UserService(YouTubeDbContext dbContext)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public async Task<UserLoginResponseModel> Login(UserLoginnRequestModel request)
        {

            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.EmailAddress == request.Email && x.Password == request.Password);
            if (user == null)
           
                return null;
           var generatedToken = GenerateRandomString(32);   
            await StoreUserToken(request.Email, generatedToken);

            return new UserLoginResponseModel
            {
                Email = user.EmailAddress,
                FullName = user.FullName,
                UserToken = generatedToken
            };
        }

        public async Task<bool> ValidateUserToken(string userToken)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.LastUserToken == userToken);
            return user is not null;
        }

        private async  Task StoreUserToken(string email, string token)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.EmailAddress == email);

            if (user is not null)
            
                user.LastUserToken = token;
            
            await dbContext.SaveChangesAsync();
        }
        private static string GenerateRandomString(int length)
        {
            var randomChars = Enumerable.Repeat(chars, 10)
              .Select(s => s[Random.Shared.Next(s.Length)]);
            return new string(randomChars.ToArray());
        }

    }

}
