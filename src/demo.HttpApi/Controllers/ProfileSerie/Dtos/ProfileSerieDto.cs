using System;
using System.Collections.Generic;

namespace Simulation.SimulationHub.ProfileSerie.Dtos
{
    public class ProfileSerieDto
    {
        public string Attribute { get; set; }
        public IEnumerable<ProfileValueDto> Values { get; set; }

        public ProfileSerieDto()
        {
            Values = new List<ProfileValueDto>();
        }
    }
}