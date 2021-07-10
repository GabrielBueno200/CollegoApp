using AutoMapper;
using Domain.Models;
using Domain.DTOs;
using Domain.ViewModels;

namespace Domain.Configurations.AutoMapper
{
    public class UserProfile : Profile {
        
        public UserProfile(){

            #region UserRegisterDTO to User

            CreateMap<UserRegisterDTO, User>();

            #endregion

            #region User to UserViewModel

            CreateMap<User, UserViewModel>();
            
            #endregion

            #region UserRegisterDTO to UserViewModel

            CreateMap<UserRegisterDTO, UserViewModel>();

            #endregion

        }

    }
}