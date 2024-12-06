using AutoMapper;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;
using TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.BaseDTO;

namespace TrialsSystem.UsersService.Api.Mapping
{
    public class DeviceMappingProfile:Profile
    {
        public DeviceMappingProfile()
        {
            CreateMap<CreateDeviceCommand, Device>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())

                .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.FirmwareVersion, opt => opt.MapFrom(src => src.FirmwareVersion))
                .ForMember(dest => dest.DeviceTypeId, opt => opt.MapFrom(src => src.TypeId))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => new DeviceType { Id = src.TypeId }))
                .ForMember(dest => dest.Users, opt => new List<User>());

            CreateMap<UpdateDeviceCommand, Device>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())

                .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.FirmwareVersion, opt => opt.MapFrom(src => src.FirmwareVersion))
                .ForMember(dest => dest.DeviceTypeId, opt => opt.MapFrom(src => src.TypeId))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => new DeviceType { Id = src.TypeId }))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.UserIds.Select(id => new User { Id = id})));

            CreateMap<Device, GetDeviceResponse>()
                .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.FirmwareVersion, opt => opt.MapFrom(src => src.FirmwareVersion))
                .ForMember(dest => dest.DeviceType, opt => opt.MapFrom(src => new IdNameDto { Id = src.Type.Id, Name = src.Type.Name }))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users.Select(u => new IdNameDto { Id = u.Id, Name = u.Name + " " + u.Surname}).ToArray()));

            CreateMap<Device, GetDevicesResponse>()
                 .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.FirmwareVersion, opt => opt.MapFrom(src => src.FirmwareVersion))
                .ForMember(dest => dest.DeviceTypeId, opt => opt.MapFrom(src => src.Type.Id))
                .ForMember(dest => dest.UserNames, opt => opt.MapFrom(src => src.Users.Select(u => u.Name + " " + u.Surname).ToArray()));

            CreateMap<Device, CreateDeviceResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.FirmwareVersion, opt => opt.MapFrom(src => src.FirmwareVersion))
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.DeviceTypeId));

            CreateMap<Device, UpdateDeviceResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.SerialNumber))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.FirmwareVersion, opt => opt.MapFrom(src => src.FirmwareVersion))
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.DeviceTypeId))
                .ForMember(dest => dest.UserIds, opt => opt.MapFrom(src => src.Users.Select(u => u.Id).ToArray()));
        }
    }
}
