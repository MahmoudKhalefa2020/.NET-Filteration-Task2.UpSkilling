namespace Task2.UpSkilling.Dtos
{
    public class TeamMemberDto
    {

        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public List<TasksDto>? Tasks { get; set; }

    }
}
