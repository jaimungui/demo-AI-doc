using System;
using System.Collections.Generic;

namespace Simulation.SimulationHub.ProfileSerie.Dtos;

public class GetScenarioProfilesDto
{
    public Dictionary<Guid,List<ScenarioProfileDto>> ScenarioProfiles { get; set; }

    public GetScenarioProfilesDto()
    {
        ScenarioProfiles = new Dictionary<Guid, List<ScenarioProfileDto>>();
    }
}