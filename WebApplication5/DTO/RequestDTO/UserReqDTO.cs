namespace WebApplication5.DTO.RequestDTO
{
    public class UserReqDTO
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public string? Phone { get; set; }
    }
}
