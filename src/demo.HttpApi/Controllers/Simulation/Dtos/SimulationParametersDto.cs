using System;

namespace Simulation.SimulationHub.Simulation.Dtos
{

    public class SimulationParametersDto : BaseSimulationParametersDto
    {
        public DateTimeOffset Date { get; set; }
        public TimeSpan StartDate { get; set; }
        public TimeSpan StopDate { get; set; }
    }
}
