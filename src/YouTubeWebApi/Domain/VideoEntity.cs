namespace YouTubeWebApi.Domain
{
    public class VideoEntity
    {
        public string  Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public string VideoUrl { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual UserEntity User { get;set; }
    }
}
