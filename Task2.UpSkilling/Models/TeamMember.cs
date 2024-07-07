using System.ComponentModel.DataAnnotations;

namespace Task2.UpSkilling.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [EmailAddress]
        public string? Email { get; set; }


        public virtual ICollection<Tasks> Tasks { get; } = new HashSet<Tasks>();
    }
}
