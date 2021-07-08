using AutoMapper;
using Domain;
using Domain.DTOs;
using Domain.ViewModels;

namespace API.Configurations.AutoMapper
{
    public class UserSetup : Profile {
        
        public UserSetup(){

            #region UserRegisterDTO to User

            CreateMap<UserRegisterDTO, User>();

            #endregion

            #region User to UserViewModel

            CreateMap<User, UserViewModel>();
            
            #endregion

        }

    }
}