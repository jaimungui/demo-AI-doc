using System;

namespace Simulation.SimulationHub.Simulation.Dtos
{

    public class CyclicSimulationParametersDto : BaseSimulationParametersDto
    {
        public TimeSpan Cycle { get; set; }
        public TimeSpan Period { get; set; }
    }
}
