
using AutoMapper;
using TrialsSystem.UserTaskService.Domain.AggregatesModel.UserTaskAggregate;
using TrialsSystem.UserTaskService.Api.Application.Commands;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;

namespace TrialsSystem.UserTaskService.Infrastructure.Mapping
{
    public class UserTaskMappingProfile:Profile
    {
        public UserTaskMappingProfile() {

            CreateMap<CreateUserTaskCommand, UserTask>()
                .ConstructUsing(dest => new UserTask(dest.Name, dest.UserId, dest.AdditionalProperties))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());

            DisableConstructorMapping();

            CreateMap<UpdateUserTaskCommand, UserTask>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());

            CreateMap<UserTask, CreateUserTaskResponse>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => src.CreatedDate));

            CreateMap<UserTask, UpdateUserTaskResponse>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.CreatedDateTime,opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.LastUpdatedDateTime, opt => opt.MapFrom(src => src.LastModifiedDate));

            CreateMap<UserTask, GetUserTaskResponse>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.LastUpdatedDateTime, opt => opt.MapFrom(src => src.LastModifiedDate));

        }
    }
}
