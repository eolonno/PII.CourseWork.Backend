namespace Entities.DTOs
{
    public class UserDetailForUpdateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}