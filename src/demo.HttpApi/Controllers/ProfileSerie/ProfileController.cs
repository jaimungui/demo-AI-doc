using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simulation.SimulationHub.ProfileSerie.Dtos;
using Simulation.SimulationHub.ProfileSerie.GetProfileSeries;
using Simulation.SimulationHub.ProfileSerie.GetScenarioProfiles;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Simulation.SimulationHub.ScenarioProfile;

[ApiController]
[Route("api/profile")]
public class ProfileController : BaseSimulationHubController
{
    public ProfileController(IServiceProvider serviceProvider) : base(serviceProvider) { }

    [HttpGet]
    [ProducesResponseType(typeof(GetScenarioProfilesDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<ActionResult<GetScenarioProfilesDto>> GetScenarioProfiles([FromQuery] List<Guid> scenarioIds, CancellationToken ct)
    {
        var response = await Mediator.Send(new GetScenarioProfilesCmd { ScenarioIds = scenarioIds }, ct);
        var responseDto = Mapper.Map<GetScenarioProfilesDto>(response);

        return Ok(responseDto);
    }

    [HttpGet("{profileId}")]
    [ProducesResponseType(typeof(GetProfileSeriesDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
    public async Task<ActionResult<IEnumerable<GetProfileSeriesDto>>> GetProfileSerie([FromRoute] Guid profileId, [FromQuery] DateTimeOffset date, CancellationToken ct)
    {
        var response = await Mediator.Send(new GetProfileSeriesCmd { ProfileId = profileId, Date = date }, ct);
        var responseDto = Mapper.Map<GetProfileSeriesDto>(response);

        return Ok(responseDto);
    }
}
