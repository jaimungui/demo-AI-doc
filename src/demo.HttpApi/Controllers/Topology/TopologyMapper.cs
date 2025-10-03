using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.AutoMapper;

namespace Simulation.SimulationHub.Topology
{
    public class TopologyMapper : Profile
    {
        public TopologyMapper()
        {
            CreateMap<TopologyDto, SendTopologyCmd>()
                .Ignore(x => x.InstanceId)
                .ForMember(dst => dst.Objects, map => map.MapFrom<TranformObjects>());

            CreateMap<PathDto, PathCmd>();

            CreateMap<PathItemDto, PathItemCmd>();

            CreateMap<ProfileSettingsDto, ProfileSettingsCmd>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom((src) => src.Id));

            CreateMap<ObjectTopologyDto, NetworkElementCmd>()
                .Ignore(x => x.Name)
                .ForMember(dst => dst.Type, opt => opt.MapFrom((src) => src.ObjectType));

            CreateMap<ProfilePathDto, ProfileCmd>();

            CreateMap<GetNetworkElementsCmdResponse, NetworkElementResponseDto>();
        }
    }

    public class TranformObjects : IValueResolver<TopologyDto, SendTopologyCmd, List<NetworkElementCmd>>
    {
        public List<NetworkElementCmd> Resolve(TopologyDto source, SendTopologyCmd destination, List<NetworkElementCmd> destMember, ResolutionContext context)
        {
            var sol = new List<NetworkElementCmd>();

            foreach (var (itDicc, networkElement) in
                     from itDicc in source.Objects
                     let networkElement = context.Mapper.Map<NetworkElementCmd>(itDicc.Value)
                     select (itDicc, networkElement))
            {
                networkElement.Name = itDicc.Key;
                sol.Add(networkElement);
            }

            return sol;
        }
    }
}
