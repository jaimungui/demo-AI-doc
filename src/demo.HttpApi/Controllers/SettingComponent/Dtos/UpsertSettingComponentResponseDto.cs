using System.Collections.Generic;

namespace Simulation.SimulationHub.SettingComponent.Dtos;

public class UpsertSettingComponentResponseDto
{
    public List<string> Success { get; set; }
    public List<string> SuccessUsers { get; set; }
}
