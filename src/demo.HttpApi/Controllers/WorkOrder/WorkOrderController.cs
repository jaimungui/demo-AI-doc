using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simulation.SimulationHub.WorkOrder.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulation.SimulationHub.WorkOrder;

[ApiController]
[Route("api/work-order")]
public class WorkOrderController : BaseSimulationHubController
{
    public WorkOrderController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    [HttpGet("execution/{executionId}")]
    [ProducesResponseType(typeof(IEnumerable<WorkOrderElementResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<IActionResult> GetWorkOrdersByExecution(Guid executionId, CancellationToken ct)
    {
        var response = await Mediator.Send(new GetWorkOrderByExecutionCmd { ExecutionId = executionId });
        return Ok(Mapper.Map<IEnumerable<WorkOrderElementResponseDto>>(response));
    }

    [HttpGet("element/{networkElementId}")]
    [ProducesResponseType(typeof(IEnumerable<WorkOrderElementResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<IActionResult> GetWorkOrdersByElement(Guid networkElementId, CancellationToken ct)
    {
        var response = await Mediator.Send(new GetWorkOrderByNetworkElementCmd { NetworkElementId = networkElementId });
        return Ok(Mapper.Map<IEnumerable<WorkOrderElementResponseDto>>(response));
    }
}
