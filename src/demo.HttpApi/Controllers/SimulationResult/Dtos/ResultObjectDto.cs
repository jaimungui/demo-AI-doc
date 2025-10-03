using Simulation.SimulationHub.WorkOrder.Dtos;
using System.Collections.Generic;

namespace Simulation.SimulationHub.SimulationResult.Dtos;

public class ResultObjectDto
{
    public Dictionary<string, TimeSerieDataDto> Results { get; set; } = new Dictionary<string, TimeSerieDataDto>();
    public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
    public List<AddWorkOrderDto> WorkOrders { get; set; }
}


