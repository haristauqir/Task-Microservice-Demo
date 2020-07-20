using System;

namespace MicroserviceDemo.Services.User.Domain.Entities
{
    public partial class AppUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
    }
}
