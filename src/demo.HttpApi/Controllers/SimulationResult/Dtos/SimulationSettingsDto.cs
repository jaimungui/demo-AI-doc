using System;

namespace Simulation.SimulationHub.SimulationResult.Dtos;


public class SimulationSettingsDto
{
    public string ScenarioName { get; set; }
    public bool IsCyclic { get; set; }
    public Guid? SnapshotId { get; set; }
    public string SnapshotName { get; set; }
    public string GroupName { get; set; }
    public bool IsActive { get; set; }
}


