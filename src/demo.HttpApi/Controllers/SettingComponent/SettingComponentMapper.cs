using AutoMapper;
using Simulation.SimulationHub.SettingComponent.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.SimulationHub.SettingComponent;

internal class SettingComponentMapper : Profile
{
    public SettingComponentMapper()
    {
        CreateMap<UpsertSettingComponentDto, UpsertSettingComponentCmd>()
            .ForMember(dest => dest.UserCode, src => src.Ignore())
            .ForMember(dest => dest.ComponentTypeId, map => map.MapFrom((src) => src.ComponentTypeId.HasValue ? src.ComponentTypeId.Value.ToString() : null));

        CreateMap<UpsertSettingComponentCmdResponse, UpsertSettingComponentResponseDto>();

        CreateMap<SettingComponentDto, SettingComponentCmd>();

        CreateMap<DeleteSettingComponentDto, DeleteSettingComponentCmd>()
           .ForMember(x => x.UserCode, y => y.Ignore());

        CreateMap<DeleteSettingComponentCmdResponse, DeleteSettingComponentResponseDto>();
    }
}
