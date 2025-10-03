using System;
using System.Collections.Generic;

namespace Simulation.SimulationHub.Topology;

public class TopologyDto
{
    public Guid ScenarioId { get; set; }
    public Dictionary<string, ObjectTopologyDto> Objects { get; set; } = new Dictionary<string, ObjectTopologyDto>();
    public List<PathDto> Paths { get; set; } = new List<PathDto>();
    public List<ProfilePathDto> Profiles { get; set; } = new List<ProfilePathDto>();
    public List<ProfileSettingsDto> ProfileSettings { get; set; } = new List<ProfileSettingsDto>();
}
