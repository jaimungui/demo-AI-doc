using System.Collections.Generic;

namespace Simulation.SimulationHub.SimulationResult.Dtos;

public class NetworkElementTypeDto
{
    public string ObjectType { get; set; }
    public string OriginalObjectType { get; set; }
    public bool HasLength { get; set; }
    public List<ConfigurationParameterDataDto> Definitions { get; set; } = new List<ConfigurationParameterDataDto>();
}