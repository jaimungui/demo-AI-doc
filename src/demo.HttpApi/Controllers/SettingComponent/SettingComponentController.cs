using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simulation.SimulationHub.SettingComponent.Dtos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Http;

namespace Simulation.SimulationHub.SettingComponent;

[ApiController]
[Route("api/settings")]
public class SettingComponentController : BaseSimulationHubController
{
    public SettingComponentController(IServiceProvider serviceProvider) : base(serviceProvider) { }

    [HttpGet("{componentArea}/{componentKey}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetSettingComponent([FromRoute] string componentArea, [FromRoute] string componentKey, CancellationToken ct)
    {
        var cmd = new GetSettingComponentCmd
        {
            ComponentArea = componentArea,
            ComponentKey = componentKey
        };

        var response = await Mediator.Send(cmd, ct);

        return Content(response.SettingValue, MimeTypes.Application.Json);
    }

    [HttpPost]
    [ProducesResponseType(typeof(UpsertSettingComponentResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<IActionResult> Upsert([FromBody] UpsertSettingComponentDto requestDto, CancellationToken ct)
    {
        var cmd = Mapper.Map<UpsertSettingComponentCmd>(requestDto);
        var response = await Mediator.Send(cmd, ct);
        var responseDto = Mapper.Map<UpsertSettingComponentResponseDto>(response);

        return Ok(responseDto);
    }

    [HttpPost("bulk")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<IActionResult> BulkUpsert([FromBody] List<UpsertSettingComponentDto> requestsDto, CancellationToken ct)
    {
        List<UpsertSettingComponentResponseDto> saveResult = new List<UpsertSettingComponentResponseDto>();

        foreach (var request in requestsDto)
        {
            var cmd = Mapper.Map<UpsertSettingComponentCmd>(request);
            var response = await Mediator.Send(cmd, ct);
            var responseDto = Mapper.Map<UpsertSettingComponentResponseDto>(response);
            saveResult.Add(responseDto);
        }

        return Ok(true);
    }

    [HttpGet("{componentArea}/{componentKey}/level")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetSettingComponentLevel([FromRoute] string componentArea, [FromRoute] string componentKey, CancellationToken ct)
    {
        var cmd = new GetSettingComponentLevelCmd
        {
            ComponentArea = componentArea,
            ComponentKey = componentKey
        };
        var response = await Mediator.Send(cmd, ct);

        return Ok(response.ComponentLevel);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<IActionResult> DeleteSettingComponent([FromBody] DeleteSettingComponentDto requestDto, CancellationToken ct)
    {
        var cmd = Mapper.Map<DeleteSettingComponentCmd>(requestDto);
        var response = await Mediator.Send(cmd, ct);
        var responseDto = Mapper.Map<DeleteSettingComponentResponseDto>(response);

        return Ok(responseDto);
    }
}

