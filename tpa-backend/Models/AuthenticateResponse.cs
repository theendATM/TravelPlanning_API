namespace tpa_backend.Models
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Phone = user.Phone;
            Email = user.Email;
            Token = token;
        }
    }
}
