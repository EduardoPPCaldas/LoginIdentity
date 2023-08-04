using AutoMapper;
using LoginSimulator.DTOs;
using LoginSimulator.Models;
using Microsoft.AspNetCore.Identity;

namespace LoginSimulator.Services;

public class UserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly TokenService _tokenService;

    public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }
    public async Task<User> Create(CreateUserDTO dto)
    {
        User user = _mapper.Map<User>(dto);

        var identityResult = await _userManager.CreateAsync(user, dto.Password);
        if(identityResult.Succeeded)
            return user;
        
        throw new ApplicationException("Failed to create user");
    }

    public async Task<string> Login(LoginUserDTO dto)
    {
        var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
        
        if(!result.Succeeded)
            throw new ApplicationException("User not authorized");
        
        var user = _signInManager
            .UserManager
            .Users
            .FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());
        
        if(user is null)
            throw new InvalidOperationException("User not found");

        var token = _tokenService.GenerateToken(user);

        return token;
    }
}
