using System.Threading.Tasks;

namespace EmployeeTracker.Infrastructure.Abstractions.Services
{
    public interface IAuthenticationService : IScopedService
    {
        Task<LoginResponseDTO> Login(InputRequestDTO input);
        Task<RegisterResponseDTO> Register(RegisterRequestDTO request);
    }

    public class LoginResponseDTO
    {
        public string Token { get; set; }
    }

    public class InputRequestDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class RegisterRequestDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
    }

    public class RegisterResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MailAddress { get; set; }
        public string UserName { get; set; }
    }
}