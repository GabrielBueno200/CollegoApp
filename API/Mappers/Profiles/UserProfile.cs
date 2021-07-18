using AutoMapper;
using Domain.Models;
using Application.ViewModels;
using Application.Core.DTOs;

namespace API.Mappers
{
    public class UserProfile : Profile {
        
        public UserProfile(){

            CreateMap<UserRegisterDTO, User>();
            CreateMap<User, UserViewModel>();
            CreateMap<UserRegisterDTO, UserViewModel>();

        }

    }
}