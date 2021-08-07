using System;
using System.Threading.Tasks;
using EmployeeTracker.Core.Entities;
using EmployeeTracker.Infrastructure.Abstractions.Services;
using Microsoft.AspNetCore.Identity;

namespace EmployeeTracker.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _manager;

        public AuthenticationService(UserManager<User> manager)
        {
            _manager = manager;
        }

        public async Task<LoginResponseDTO> Login(InputRequestDTO input)
        {
            var user = await _manager.FindByNameAsync(input.UserName);
            var result = await _manager.CheckPasswordAsync(user, input.Password);
            if (result)
            {
                return new LoginResponseDTO
                {
                    Token = "token"
                };
            }
            else
            {
                throw new Exception("Hatalı giriş!");
            }

            return new LoginResponseDTO();
        }

        public async Task<RegisterResponseDTO> Register(RegisterRequestDTO request)
        {
            var user = new User
            {
                Email = request.MailAddress,
                Name = request.Name,
                Surname = request.Surname,
                UserName = request.UserName
                
            };
            var registerResult = await _manager.CreateAsync(user,request.Password);
            if (registerResult.Succeeded)
            {
                return new RegisterResponseDTO
                {
                    Id = user.Id,
                    Name = request.Name,
                    Surname = request.Surname,
                    MailAddress = request.MailAddress,
                    UserName = request.UserName
                };
            }
            else
            {
                throw new Exception("Kayıt esnasında hata oluştu. Yeniden deneyiniz.");
            }
            
        }
    }
}