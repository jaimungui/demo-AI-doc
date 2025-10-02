using System.Collections.Generic;
using System;

namespace Simulation.SimulationHub.WorkOrder.Dtos;

public class WorkOrderElementResponseDto
{
    public Guid Id { get; set; }
    public Guid NetworkElementId { get; set; }
    public List<WorkOrderResponseDto> WorkOrders { get; set; }
}
