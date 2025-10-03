using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simulation.SimulationHub.Simulation.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Simulation.SimulationHub.Simulation
{
    [ApiController]
    [Route("api/simulation")]
    public partial class SimulationController : BaseSimulationHubController
    {
        public SimulationController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpPost("start/{instanceId}")]
        [ProducesResponseType(typeof(SimulationActionResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
        public async Task<IActionResult> StartSimulation([FromRoute] Guid instanceId, [FromBody] SimulationParametersDto simulationSettings, CancellationToken ct)
        {
            var cmd = Mapper.Map<StartSimulationCmd>(simulationSettings);
            cmd.InstaceId = instanceId;

            var cmdResponse = await Mediator.Send(cmd, ct);
            var responseDto = Mapper.Map<SimulationActionResponseDto>(cmdResponse);

            return Ok(responseDto);
        }


        [HttpPost("start-cyclic/{instanceId}")]
        [ProducesResponseType(typeof(SimulationActionResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
        public async Task<IActionResult> StartCyclicSimulation([FromRoute] Guid instanceId, [FromBody] CyclicSimulationParametersDto simulationSettings, CancellationToken ct)
        {
            var cmd = Mapper.Map<StartCyclicSimulationCmd>(simulationSettings);
            cmd.InstaceId = instanceId;

            var cmdResponse = await Mediator.Send(cmd, ct);
            var responseDto = Mapper.Map<SimulationActionResponseDto>(cmdResponse);

            return Ok(responseDto);
        }

        [HttpGet("stop/{instanceId}")]
        [ProducesResponseType(typeof(SimulationActionResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status504GatewayTimeout)]
        public async Task<IActionResult> StoptSimulation([FromRoute] Guid instanceId, CancellationToken ct)
        {
            var cmd = new StopSimulationCmd
            {
                InstaceId = instanceId
            };

            var cmdResponse = await Mediator.Send(cmd, ct);
            var responseDto = Mapper.Map<SimulationActionResponseDto>(cmdResponse);

            return Ok(responseDto);
        }
    }
}
