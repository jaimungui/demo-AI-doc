using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Simulation.SimulationHub.SettingComponent.Dtos;

public class DeleteSettingComponentDto
{
    [Required]
    public List<SettingComponentDto> SettingsToDelete { get; set; }
}

public class SettingComponentDto
{
    public string SettingArea { get; set; }
    public string SettingKey { get; set; }
}
