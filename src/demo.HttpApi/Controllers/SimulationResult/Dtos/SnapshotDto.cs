using System;

namespace Simulation.SimulationHub.SimulationResult.Dtos;

public class SnapshotDto
{
    public Guid Id { get; set; }
    public Guid InstanceId { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public Guid GroupId { get; set; }
}
