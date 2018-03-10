using AprioritFoldersTask.Models;
using AprioritFoldersTask.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AprioritFoldersTask.Mapping
{

    public class FoldersMappingProfile : Profile
    {
        public FoldersMappingProfile()
        {
            CreateMap<Folders, FolderViewModel>()
                .ForMember(dest => dest.Id,
                           opts => opts.MapFrom(src => src.Id))
                            .ForMember(dest => dest.Name,
                           opts => opts.MapFrom(src => src.Name))
                            .ForMember(dest => dest.ParentId,
                           opts => opts.MapFrom(src => src.ParentId))
                            .ForMember(dest => dest.CreationDate,
                           opts => opts.MapFrom(src => src.CreationDate));
        }
    }

}