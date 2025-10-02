using System;
using System.Collections.Generic;

namespace Simulation.SimulationHub.SimulationResult.Dtos;

public class ResultObjectRequestDto
{
    public Dictionary<int, DateTimeOffset> Steps { get; set; }
    public Dictionary<string, ResultObjectDto> Objects { get; set; }
}
