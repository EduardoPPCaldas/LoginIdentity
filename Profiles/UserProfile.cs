using AutoMapper;
using LoginSimulator.DTOs;
using LoginSimulator.Models;

namespace LoginSimulator.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDTO, User>();
    }
}
