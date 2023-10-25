using System;
namespace Jca.Sigmuni.Application.Dtos.Admins.Roles
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool? State { get; set; }
        public string? Statename { get; set; }
    }
}

