using AutoMapper;
using Domain.Models;
using Domain.DTOs;
using Domain.ViewModels;

namespace Domain.Configurations.AutoMapper
{
    public class UserProfile : Profile {
        
        public UserProfile(){

            CreateMap<UserRegisterDTO, User>();
            CreateMap<User, UserViewModel>();
            CreateMap<UserRegisterDTO, UserViewModel>();

        }

    }
}