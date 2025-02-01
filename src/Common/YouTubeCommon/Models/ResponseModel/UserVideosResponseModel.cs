using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeCommon.Models.ResponseModel
{
    public class UserVideosResponseModel
    {
        public string? VideoId { get; set; }
        public string? VideoTitle { get; set; }
        public string? VideoDescription { get; set; }
        public string? VideoUrl { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? UserEmailAddress { get; set; }
        public DateTime CreateAt { get; set; }

        //public int Views { get; set; }
        //public int Likes { get; set; }
        //public int DisLikes { get; set; }
        //public int Comment { get; set; }
    }
}
