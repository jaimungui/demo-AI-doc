using System;
using System.Collections.Generic;

namespace Simulation.SimulationHub.Simulation.Dtos
{
    public class BaseSimulationParametersDto
    {
        public Guid SnapshotId { get; set; }
        public int TimeStepMax { get; set; }
        public int TimeStepMin { get; set; }
        public List<Guid> ScenarioIds { get; set; }
    }
}
