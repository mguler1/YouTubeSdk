namespace YouTubeWebApi.Domain
{
    public class UserEntity
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastUserToken { get; set; }
        public virtual ICollection<VideoEntity> Videos { get; set; }
    }
}
