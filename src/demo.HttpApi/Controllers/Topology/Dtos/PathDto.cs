using System.Collections.Generic;

namespace Simulation.SimulationHub.Topology;

public class PathDto
{
    public string Name { get; set; }
    public List<PathItemDto> Items { get; set; }
}