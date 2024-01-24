using Microsoft.AspNetCore.Identity;
using Restaurant.Integration.Domain.Dtos;
using Restaurant.Services.AuthAPI.Mapper;
using Restaurant.Services.AuthAPI.Models;
using Restaurant.Services.AuthAPI.Models.Dtos;
using Restaurant.Services.AuthAPI.Services.Abstract;

namespace Restaurant.Services.AuthAPI.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public UserService(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<ResponseDto<BlankDto>> AssignRoleToUserAsync(int userId, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                throw new Exception("User Not Found");

            var userRoles = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRolesAsync(user, roles);

            return ResponseDto<BlankDto>.Sucess(204);
        }

        public async Task<ResponseDto<LoginResponseDto>> LoginUserAsync(LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.UserNameOrEmail);

            if (user is null)
                user = await _userManager.FindByNameAsync(loginRequestDto.UserNameOrEmail);
                if(user is null)
                    return ResponseDto<LoginResponseDto>.Fail("User not found", true, 500);
            

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if(!isValid)
                return ResponseDto<LoginResponseDto>.Fail("Password incorrect", true, 500);


            var result = await _tokenService.CreateTokenAsync(user);

            return ResponseDto<LoginResponseDto>.Sucess(result, 200);
        }

        public async Task<ResponseDto<BlankDto>> RegisterUserAsync(RegistrationRequestDto registrationRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(registrationRequestDto.Email);

            if (user is not null)
                return ResponseDto<BlankDto>.Fail("Already Registered", true, 500);

            user = await _userManager.FindByNameAsync(registrationRequestDto.UserName);

            if(user is not null)
                return ResponseDto<BlankDto>.Fail("Already Registered", true, 500);

            if(!registrationRequestDto.Password.Equals(registrationRequestDto.RePassword))
                return ResponseDto<BlankDto>.Fail("Password not equals with RePassword", true, 500);


            user = ObjectMapper.Mapper.Map<AppUser>(registrationRequestDto);  

            var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);

            await AssignRoleToUserAsync(user.Id, new() { registrationRequestDto.Role });

            if (!result.Succeeded)
                return ResponseDto<BlankDto>.Fail("User Created Fail", true, 500);


            return ResponseDto<BlankDto>.Sucess(201);

        }



    }
}
