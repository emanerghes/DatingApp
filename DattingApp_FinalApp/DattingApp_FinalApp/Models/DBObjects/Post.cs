using System;
using System.Collections.Generic;

namespace DattingApp_FinalApp.Models.DBObjects
{
    public partial class Post
    {
        public Guid Id { get; set; }
        public string? Photo { get; set; }
        public string? About { get; set; }
        public string UserEmail { get; set; } = null!;
    }
}
