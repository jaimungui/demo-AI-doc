using System;

namespace Simulation.SimulationHub.SimulationResult.Dtos;

public class SimulationSettingsResponseDto
{
    public Guid SnapshotId { get; set; }
    public Guid ScenarioId { get; set; }
    public Guid ExecutionId { get; set; }
}
