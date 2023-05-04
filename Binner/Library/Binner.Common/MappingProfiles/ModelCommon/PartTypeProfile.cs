﻿using AutoMapper;
using Binner.Model;
using Binner.Model.Responses;
using Binner.StorageProvider.EntityFrameworkCore;
using DataModel = Binner.Data.Model;

namespace Binner.Common.MappingProfiles.ModelCommon
{
    public class PartTypeProfile : Profile
    {
        public PartTypeProfile()
        {
            CreateMap<DataModel.PartType, PartType>(MemberList.None)
                .ForMember(x => x.DateCreatedUtc, options => options.MapFrom(x => x.DateCreatedUtc))
                .ForMember(x => x.ParentPartTypeId, options => options.MapFrom(x => x.ParentPartTypeId))
                .ForMember(x => x.PartTypeId, options => options.MapFrom(x => x.PartTypeId))
                .ForMember(x => x.Name, options => options.MapFrom(x => x.Name))
                .ForMember(x => x.UserId, options => options.MapFrom(x => x.UserId))
                ;

            CreateMap<PartType, DataModel.PartType>(MemberList.None)
                .ForMember(x => x.ParentPartTypeId, options => options.MapFrom(x => x.ParentPartTypeId))
                .ForMember(x => x.PartTypeId, options => options.MapFrom(x => x.PartTypeId))
                .ForMember(x => x.Name, options => options.MapFrom(x => x.Name))
                .ForMember(x => x.UserId, options => options.MapFrom(x => x.UserId))
                .ForMember(x => x.DateCreatedUtc, options => options.Ignore())
                .ForMember(x => x.DateModifiedUtc, options => options.Ignore())
                .ForMember(x => x.User, options => options.Ignore())
                .ForMember(x => x.ParentPartType, options => options.Ignore())
                .ForMember(x => x.Parts, options => options.Ignore())
                .ForMember(x => x.OrganizationId, options => options.Ignore())
                ;

            CreateMap<DataModel.PartType, PartTypeResponse>()
                .ForMember(x => x.DateCreatedUtc, options => options.MapFrom(x => x.DateCreatedUtc))
                .ForMember(x => x.ParentPartTypeId, options => options.MapFrom(x => x.ParentPartTypeId))
                .ForMember(x => x.PartTypeId, options => options.MapFrom(x => x.PartTypeId))
                .ForMember(x => x.Name, options => options.MapFrom(x => x.Name))
                .ForMember(x => x.Parts, options => options.MapFrom(x => x.Parts != null ? x.Parts.Count : 0))
                ;

            CreateMap<PartType, CachedPartTypeResponse>()
                .ForMember(x => x.ParentPartTypeId, options => options.MapFrom(x => x.ParentPartTypeId))
                .ForMember(x => x.PartTypeId, options => options.MapFrom(x => x.PartTypeId))
                .ForMember(x => x.Name, options => options.MapFrom(x => x.Name))
                .ForMember(x => x.UserId, options => options.MapFrom(x => x.UserId))
                .ForMember(x => x.OrganizationId, options => options.Ignore())
                .ForMember(x => x.DateCreatedUtc, options => options.MapFrom(x => x.DateCreatedUtc))
                .ForMember(x => x.DateModifiedUtc, options => options.Ignore())
                .ForMember(x => x.Parts, options => options.Ignore())
                .ForMember(x => x.IsSystem, options => options.MapFrom(x => x.UserId == null))
                .ForMember(x => x.ParentPartType, options => options.Ignore())
                ;
            CreateMap<CachedPartTypeResponse, PartType>()
                .ForMember(x => x.ParentPartTypeId, options => options.MapFrom(x => x.ParentPartTypeId))
                .ForMember(x => x.PartTypeId, options => options.MapFrom(x => x.PartTypeId))
                .ForMember(x => x.Name, options => options.MapFrom(x => x.Name))
                .ForMember(x => x.UserId, options => options.MapFrom(x => x.UserId))
                .ForMember(x => x.DateCreatedUtc, options => options.MapFrom(x => x.DateCreatedUtc))
                ;
            CreateMap<CachedPartTypeResponse, PartTypeResponse>()
                .ForMember(x => x.ParentPartTypeId, options => options.MapFrom(x => x.ParentPartTypeId))
                .ForMember(x => x.PartTypeId, options => options.MapFrom(x => x.PartTypeId))
                .ForMember(x => x.Name, options => options.MapFrom(x => x.Name))
                .ForMember(x => x.DateCreatedUtc, options => options.MapFrom(x => x.DateCreatedUtc))
                .ForMember(x => x.Parts, options => options.MapFrom(x => x.Parts))
                .ForMember(x => x.ParentPartType, options => options.MapFrom(x => x.ParentPartType != null ? x.ParentPartType.Name : null))
                ;
        }
    }
}
