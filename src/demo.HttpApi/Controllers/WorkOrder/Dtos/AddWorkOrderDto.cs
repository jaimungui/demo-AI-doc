using System;

namespace Simulation.SimulationHub.WorkOrder.Dtos;

public class AddWorkOrderDto
{
    public DateTimeOffset TimeStamp { get; set; }
    public double Action { get; set; }
}
