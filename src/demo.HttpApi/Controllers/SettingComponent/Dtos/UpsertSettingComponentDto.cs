using System.ComponentModel.DataAnnotations;

namespace Simulation.SimulationHub.SettingComponent.Dtos;

public class UpsertSettingComponentDto
{
    [Required]
    public string SettingValue { get; set; }
    public string SettingArea { get; set; }
    public string SettingKey { get; set; }
    public bool SaveAsDefault { get; set; }
    public int? ComponentTypeId { get; set; }
    public bool? CreateComponentIfNoExists { get; set; }
}
