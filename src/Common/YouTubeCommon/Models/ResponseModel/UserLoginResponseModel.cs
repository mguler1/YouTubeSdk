using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeCommon.Models.ResponseModel
{
    public  class UserLoginResponseModel
    {
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? UserToken { get; set; }
    }
}
