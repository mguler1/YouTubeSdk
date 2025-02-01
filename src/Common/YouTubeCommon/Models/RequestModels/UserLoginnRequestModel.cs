using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeCommon.Models.RequestModels
{
    public class UserLoginnRequestModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
