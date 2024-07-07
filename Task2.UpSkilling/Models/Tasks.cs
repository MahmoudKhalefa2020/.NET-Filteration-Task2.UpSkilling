using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task2.UpSkilling.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        public bool Status { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }

        [ForeignKey(nameof(TeamMember))]
        public int MemberId { get; set; }
        public virtual TeamMember TeamMember { get; set; }
    }
}
