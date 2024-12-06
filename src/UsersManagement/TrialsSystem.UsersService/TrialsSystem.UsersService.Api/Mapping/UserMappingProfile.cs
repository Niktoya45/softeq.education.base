using AutoMapper;
using TrialsSystem.UsersService.Api.Application.Commands.UsersCommands;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;
using TrialsSystem.UsersService.Infrastructure.Models.BaseDTO;

namespace TrialsSystem.UsersService.Api.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserCommand, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())

                .ForMember(dest => dest.City, opt => opt.MapFrom(src => new City { Id = src.CityId }))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => new Gender { Id = src.GenderId }))
                .ForMember(dest => dest.Devices, opt => new List<Device>());

            CreateMap<UpdateUserCommand, User>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())

                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => new City { Id = src.CityId }))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => new Gender { Id = src.GenderId }))
                .ForMember(dest => dest.Devices, opt => opt.MapFrom(src => src.DeviceIds.Select(ds => new Device { Id = ds }).ToArray()));

            CreateMap<User, GetUserResponse>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => new IdNameDto { Id = src.City.Id, Name = src.City.Name }))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => new IdNameDto { Id = src.Gender.Id, Name = src.Gender.Name }))
                .ForMember(dest => dest.DevicesSN, opt => opt.MapFrom(src => src.Devices.Select(d => d.SerialNumber).ToArray()));

            CreateMap<User, GetUsersResponse>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => src.Gender.Name));

            CreateMap<User, CreateUserResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.GenderId));

            CreateMap<User, UpdateUserResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(dest => dest.DevicesSN, opt => opt.MapFrom(src => src.Devices.Select(d => d.SerialNumber).ToArray()));
        }
    }
}
