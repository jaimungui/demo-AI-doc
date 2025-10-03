using AutoMapper;
using Simulation.SimulationHub.Simulation.Dtos;

namespace Simulation.SimulationHub.Simulation
{
    public class SimulationMapper : Profile
    {
        public SimulationMapper()
        {
            CreateMap<SimulationParametersDto, StartSimulationCmd>();
            CreateMap<CyclicSimulationParametersDto, StartCyclicSimulationCmd>();

            CreateMap<SimulationActionCmdResponse, SimulationActionResponseDto>();
        }
    }
}
