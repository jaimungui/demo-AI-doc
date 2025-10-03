using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Simulation.SimulationHub.GeoServer;
using Simulation.SimulationHub.Registration.Dtos;
using Simulation.SimulationHub.SimulationResult.CleanSnapshot;
using Simulation.SimulationHub.SimulationResult.Dtos;
using Simulation.SimulationHub.SimulationResult.GetSnapshotsByInstance;
using Simulation.SimulationHub.SimulationResult.UpdateScenarioStatus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Simulation.SimulationHub.SimulationResult;

[ApiController]
[Route("api/result")]
public class ResultController : BaseSimulationHubController
{
    readonly ILogger<ResultController> _logger;
    public ResultController(IServiceProvider serviceProvider, ILogger<ResultController> logger) : base(serviceProvider)
    {
        _logger = logger;
    }

    [HttpPost("{simulationExecutionId}")]
    [ProducesResponseType(typeof(ResultObjectRequestCmdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<IActionResult> SendScenarioResults([FromRoute] Guid simulationExecutionId, [FromBody] ResultObjectRequestDto resultObjectRequestDto)
    {
        var cmd = Mapper.Map<ResultObjectRequestCmd>(resultObjectRequestDto);
        cmd.SimulationExecutionId = simulationExecutionId;

        var response = await Mediator.Send(cmd);

        return Ok(response);
    }

    [HttpPost("{instanceId}/scenario")]
    [ProducesResponseType(typeof(SimulationSettingsResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<IActionResult> SendSimulationSettings([FromRoute] Guid instanceId, [FromBody] SimulationSettingsDto simulationSettings)
    {
        var cmd = Mapper.Map<SimulationSettingsCmd>(simulationSettings);
        cmd.InstaceId = instanceId;

        var cmdResponse = await Mediator.Send(cmd);
        var responseDto = Mapper.Map<SimulationSettingsResponseDto>(cmdResponse);

        return Ok(responseDto);
    }

    [HttpPost("{simulationExecutionId}/metadata")]
    [ProducesResponseType(typeof(ScenarioSettingsResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<IActionResult> SendScenarioSettings([FromRoute] Guid simulationExecutionId, [FromBody] ScenarioSettingsDto scenarioSettings)
    {
        var cmd = Mapper.Map<ScenarioSettingsCmd>(scenarioSettings);
        cmd.ExecutionId = simulationExecutionId;

        var responseCmd = await Mediator.Send(cmd);

        return Ok(responseCmd);
    }

    [HttpPost("{simulationExecutionId}/publish")]
    [ProducesResponseType(typeof(PublishScenarioExecutionCmdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<IActionResult> PublishScenarioResults([FromRoute] Guid simulationExecutionId)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        var publishScenarioExecutionCmd = new PublishScenarioExecutionCmd
        {
            SimulationExecutionId = simulationExecutionId
        };

        var response = await Mediator.Send(publishScenarioExecutionCmd);

        stopWatch.Stop();
        _logger.LogInformation($"PublishScenarioResults {simulationExecutionId} elapsed:{stopWatch.Elapsed}");

        if (response.Status == Staging.PublishResultsStatus.Published)
        {
            var generateGeoServerLayerCmd = new GenerateGeoServerLayerCmd
            {
                SimulationExecutionId = simulationExecutionId
            };

            await Mediator.Send(generateGeoServerLayerCmd);
        }

        return Ok(response);
    }

    [HttpGet("{instanceId}/snapshot")]
    [ProducesResponseType(typeof(IEnumerable<SnapshotDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<ActionResult<IEnumerable<SnapshotDto>>> GetSnapshotsByInstance([FromRoute] Guid instanceId, CancellationToken ct)
    {
        var cmd = new GetSnapshotByInstanceCmd { InstanceId = instanceId };
        var response = await Mediator.Send(cmd, ct);
        var snapshots = Mapper.Map<IEnumerable<SnapshotDto>>(response.Snapshots);
        return Ok(snapshots);
    }

    [HttpPut("{scenarioId}/scenario")]
    [ProducesResponseType(typeof(ScenarioResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<ActionResult<ScenarioResponseDto>> SetScenarioStatus([FromRoute] Guid scenarioId, [FromBody] UpdateScenarioStatusDto updateScenarioStatusDto, CancellationToken ct )
    {
        var cmd = Mapper.Map<UpdateScenarioStatusCmd>(updateScenarioStatusDto);
        cmd.Id = scenarioId;
        var response = await Mediator.Send(cmd, ct);
        var scenario = Mapper.Map<ScenarioResponseDto>(response.Scenario);
        return scenario;
    }

    [HttpDelete("{snapshotId}/clean-snapshot")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<ActionResult<bool>> CleanSnapshot([FromRoute] Guid snapshotId, CancellationToken ct)
    {
        var cmd = new CleanSnapshotCmd { SnapshotId = snapshotId };
        var response = await Mediator.Send(cmd, ct);
        return Ok(response.Success);
    }
}


