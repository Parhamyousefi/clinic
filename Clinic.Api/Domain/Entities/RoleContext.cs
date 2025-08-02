namespace Clinic.Api.Domain.Entities
{
    public class RoleContext
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }

        public ICollection<UserContext> Users { get; set; } = new List<UserContext>();
    }
}
