namespace DattingApp_FinalApp.Models
{
    public class LikeModel
    {
        public Guid Id { get; set; }
        public string Person { get; set; } = null!;
        public string Likes { get; set; } = null!;
    }
}
