using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MyVilla_VillaApi.Models;
using MyVilla_VillaAPI.Data;
using MyVilla_VillaAPI.Models;
using MyVilla_VillaAPI.Models.Dto;
using MyVilla_VillaAPI.Repository.IRepostiory;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyVilla_VillaAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManagaer;
        private readonly RoleManager<IdentityRole> _roleManagaer;
        private string secretkey;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext dbContext, IConfiguration configuration, UserManager<ApplicationUser> userManagaer,RoleManager<IdentityRole> roleManagaer, IMapper mapper)
        {
            _dbContext = dbContext;
            secretkey = configuration.GetValue<string>("ApiSettings:Secret");
            _userManagaer = userManagaer;
            _mapper = mapper;
            _roleManagaer = roleManagaer;

        }
        public bool ISUniqueUser(string username)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(x => x.UserName == username);
            if (user == null) return true;
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower());
            bool isValid = await _userManagaer.CheckPasswordAsync(user, loginRequestDTO.Password);
            if (user == null || isValid == false)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };
            }
            // if user found generate JWT Token
            var roles = await _userManagaer.GetRolesAsync(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretkey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = _mapper.Map<UserDTO>(user),
                Role = roles.FirstOrDefault()
            };
            return loginResponseDTO;

        }

        public async Task<UserDTO> Register(RegisterationRequestDTO registerationRequestDTO)
        {
            ApplicationUser user = new()
            {
                UserName = registerationRequestDTO.UserName,
                Email = registerationRequestDTO.UserName,
                NormalizedEmail = registerationRequestDTO.UserName.ToUpper(),
                Name = registerationRequestDTO.Name
            };
            try
            {
                var result = await _userManagaer.CreateAsync(user, registerationRequestDTO.Password);
                if (result.Succeeded)
                {
                    if (!_roleManagaer.RoleExistsAsync("admin").GetAwaiter().GetResult())
                    {
                        await _roleManagaer.CreateAsync(new IdentityRole("admin"));
                        await _roleManagaer.CreateAsync(new IdentityRole("customer"));
                    }
                    await _userManagaer.AddToRoleAsync(user, "admin");
                    var userToReturn = _dbContext.ApplicationUsers.FirstOrDefault(u => u.UserName == registerationRequestDTO.UserName);
                    return _mapper.Map<UserDTO>(userToReturn);
                }
            }
            catch (Exception ex)
            {

            }
            return new UserDTO();
        }
    }
}
