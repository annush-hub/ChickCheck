namespace API.Dtos
{
    public class UserAuthDto
    {
        public string DisplayName { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public DateTime Expiration { get; set; }
    }
}
