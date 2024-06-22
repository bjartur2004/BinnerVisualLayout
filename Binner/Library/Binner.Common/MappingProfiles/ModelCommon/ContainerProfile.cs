using AutoMapper;
using Binner.Model;
using Binner.Model.Responses;
using Binner.StorageProvider.EntityFrameworkCore;
using DataModel = Binner.Data.Model;

namespace Binner.Common.MappingProfiles.ModelCommon
{
    public class ContainerProfile : Profile
    {
        public ContainerProfile()
        {
            CreateMap<DataModel.Container, Container>(MemberList.None)
                .ForMember(x => x.ContainerId, options => options.MapFrom(x => x.ContainerId))
                .ForMember(x => x.Label, options => options.MapFrom(x => x.Label))
                .ForMember(x => x.ParentContainerId, options => options.MapFrom(x => x.ParentContainerId))
                .ForMember(x => x.UserId, options => options.MapFrom(x => x.UserId))
                .ForMember(x => x.DateCreatedUtc, options => options.MapFrom(x => x.DateCreatedUtc))
                ;

            CreateMap<Container, DataModel.Container>(MemberList.None)
                .ForMember(x => x.ContainerId, options => options.MapFrom(x => x.ContainerId))
                .ForMember(x => x.Label, options => options.MapFrom(x => x.Label))
                .ForMember(x => x.ParentContainerId, options => options.MapFrom(x => x.ParentContainerId))
                .ForMember(x => x.UserId, options => options.MapFrom(x => x.UserId))
                .ForMember(x => x.DateCreatedUtc, options => options.Ignore())
                .ForMember(x => x.DateModifiedUtc, options => options.Ignore())
                .ForMember(x => x.User, options => options.Ignore())
                .ForMember(x => x.ParentContainer, options => options.Ignore())
                .ForMember(x => x.OrganizationId, options => options.Ignore())
                ;

            CreateMap<DataModel.Container, ContainerResponse>()
                .ForMember(x => x.ContainerId, options => options.MapFrom(x => x.ContainerId))
                .ForMember(x => x.Label, options => options.MapFrom(x => x.Label))
                .ForMember(x => x.ParentContainerId, options => options.MapFrom(x => x.ParentContainerId))
                .ForMember(x => x.DateCreatedUtc, options => options.MapFrom(x => x.DateCreatedUtc))
                ;
        }
    }
}
