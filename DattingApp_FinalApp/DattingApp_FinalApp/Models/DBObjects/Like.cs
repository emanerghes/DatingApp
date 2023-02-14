using System;
using System.Collections.Generic;

namespace DattingApp_FinalApp.Models.DBObjects
{
    public partial class Like
    {
        public Guid Id { get; set; }
        public string Person { get; set; } = null!;
        public string Likes { get; set; } = null!;
    }
}
