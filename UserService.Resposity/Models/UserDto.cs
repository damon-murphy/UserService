namespace UserService
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public string? Address { get; set; }
    }
}