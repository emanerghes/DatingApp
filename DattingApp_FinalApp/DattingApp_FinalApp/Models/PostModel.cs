namespace DattingApp_FinalApp.Models
{
    public class PostModel
    {


        public Guid Id { get; set; }
        public string? Photo { get; set; }
        public string? About { get; set; }
        public string UserEmail { get; set; } = null!;
    }
}
