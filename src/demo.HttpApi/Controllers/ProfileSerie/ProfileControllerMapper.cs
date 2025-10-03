using AutoMapper;
using Simulation.SimulationHub.ProfileSerie.Dtos;
using Simulation.SimulationHub.ProfileSerie.GetProfileSeries;
using Simulation.SimulationHub.ProfileSerie.GetScenarioProfiles;

namespace Simulation.SimulationHub.ScenarioProfile
{
    public class ProfileControllerMapper : Profile
    {
        public ProfileControllerMapper()
        {
            CreateMap<ProfileCmdResponse, ScenarioProfileDto>();
            CreateMap<GetScenarioProfilesCmdResponse, GetScenarioProfilesDto>();

            CreateMap<ProfileValueCmdResponse, ProfileValueDto>();
            CreateMap<ProfileSerieCmdResponse, ProfileSerieDto>();
            CreateMap<GetProfileSeriesCmdResponse, GetProfileSeriesDto>();
        }
    }
}
