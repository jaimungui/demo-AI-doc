using System;

namespace Simulation.SimulationHub.WorkOrder.Dtos;

public class WorkOrderResponseDto
{
    public DateTimeOffset TimeStamp { get; set; }
    public double Action { get; set; }
}
