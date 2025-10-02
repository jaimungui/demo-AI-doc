using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simulation.SimulationHub.Attribute.Dtos;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Simulation.SimulationHub.Attribute;

[ApiController]
[Route("api/attribute")]
public class AttributeController : BaseSimulationHubController
{
    public AttributeController(IServiceProvider serviceProvider) : base(serviceProvider) { }

    [HttpGet("{snapshotId}")]
    [ProducesResponseType(typeof(List<AttributeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<ActionResult<List<AttributeDto>>> GetAttributeValues([FromRoute] Guid snapshotId,
        [FromQuery] GetAttributeValuesRequest request, CancellationToken ct)
    {
        var cmd = Mapper.Map<GetAttributeValuesCmd>(request);
        cmd.SnapshotId = snapshotId;
        var response = await Mediator.Send(cmd, ct);
        var responseDto = Mapper.Map<List<AttributeDto>>(response.AttributeValues);

        return Ok(responseDto);
    }

    [HttpGet("{snapshotId}/metadata")]
    [ProducesResponseType(typeof(IEnumerable<ElementTypeCategoriesDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<ActionResult<IEnumerable<ElementTypeCategoriesDto>>> GetAttributesMetadata([FromRoute] Guid snapshotId,
        [FromQuery] Guid scenarioId, CancellationToken ct)
    {
        var cmd = new GetAttributesMetadataCmd
        {
            SnapshotId = snapshotId,
            ScenarioId = scenarioId
        };

        var response = await Mediator.Send(cmd, ct);
        var responseDto = Mapper.Map<IEnumerable<ElementTypeCategoriesDto>>(response.ElementTypeCategories);

        return Ok(responseDto);
    }



    [HttpGet("{snapshotId}/date-range")]
    [ProducesResponseType(typeof(DateRangeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<ActionResult<DateRangeDto>> GetAttributeDateRange([FromRoute] Guid snapshotId,
        [FromQuery] Guid scenarioId, CancellationToken ct)
    {
        var cmd = new GetAttributeDateRangeCmd
        {
            SnapshotId = snapshotId,
            ScenarioId = scenarioId
        };

        var response = await Mediator.Send(cmd, ct);
        var responseDto = Mapper.Map<DateRangeDto>(response);

        return Ok(responseDto);
    }
}

