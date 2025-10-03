using System.Collections.Generic;

namespace Simulation.SimulationHub.ProfileSerie.Dtos
{
    public class GetProfileSeriesDto
    {
        public string Lengend { get; set; }
        public string ChainageUnits { get; set; }
        public string ChainagePhysType { get; set; }
        public IEnumerable<ProfileSerieDto> ProfileSerieValues { get; set; }

        public GetProfileSeriesDto()
        {
            ProfileSerieValues = new List<ProfileSerieDto>();
        }
    }
}