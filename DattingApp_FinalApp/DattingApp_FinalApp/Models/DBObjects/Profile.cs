using System;
using System.Collections.Generic;

namespace DattingApp_FinalApp.Models.DBObjects
{
    public partial class Profile
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public string LookingFor { get; set; } = null!;
        public string? Email { get; set; }
    }
}
