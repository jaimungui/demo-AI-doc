using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simulation.SimulationHub.Topology;

[ApiController]
[Route("api/topology")]
public partial class TopologyController : BaseSimulationHubController
{
    readonly ILogger<TopologyController> _logger;
    public TopologyController(
        IServiceProvider serviceProvider,
        ILogger<TopologyController> logger) : base(serviceProvider)
    {
        _logger = logger;
    }

    [HttpGet("{instanceId}/{simulationScenarioId}")]
    [ProducesResponseType(typeof(CheckTopologyResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<IActionResult> CheckTopology([FromRoute] Guid instanceId, [FromRoute] Guid simulationScenarioId)
    {
        var cmd = new CheckTopologyCmd
        {
            SimulationScenarioId = simulationScenarioId
        };

        var cmdResponse = await Mediator.Send(cmd);
        var responseDto = new CheckTopologyResponseDto
        {
            IsOk = cmdResponse.IsOk
        };

        return Ok(responseDto);
    }

    [HttpGet("{instanceId}/{scenarioId}/networkelements")]
    [ProducesResponseType(typeof(IEnumerable<NetworkElementResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<ActionResult<IEnumerable<NetworkElementResponseDto>>> GetNetWorkElements([FromRoute] Guid instanceId, [FromRoute] Guid scenarioId)
    {
        var cmd = new GetNetworkElementsCmd
        {
            ScenarioId = scenarioId
        };

        var cmdResponse = await Mediator.Send(cmd);
        var responseDto = Mapper.Map<IEnumerable<NetworkElementResponseDto>>(cmdResponse);

        return Ok(responseDto);
    }

    [HttpPost("{instanceId}")]
    [ProducesResponseType(typeof(SendTopologyResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<IActionResult> SendTopology(Guid instanceId, [FromBody] TopologyDto topologyDto)
    {
        var cmd = Mapper.Map<SendTopologyCmd>(topologyDto);
        cmd.InstanceId = instanceId;

        topologyDto.Objects?.Clear();
        topologyDto.Paths?.Clear();
        topologyDto.Profiles?.Clear();
        topologyDto.ProfileSettings?.Clear();

        var cmdResponse = await Mediator.Send(cmd);
        var responseDto = new SendTopologyResponseDto
        {
            IsOk = cmdResponse.IsOk
        };

        return Ok(responseDto);
    }
}





