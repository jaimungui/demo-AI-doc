using System;
using System.Collections.Generic;

namespace Simulation.SimulationHub.SimulationResult.Dtos;

public class ScenarioSettingsDto
{
    public Guid ExecutionId { get; set; }
    public DateTimeOffset FromDate { get; set; }
    public DateTimeOffset ToDate { get; set; }
    public List<NetworkElementTypeDto> Types { get; set; }
}
