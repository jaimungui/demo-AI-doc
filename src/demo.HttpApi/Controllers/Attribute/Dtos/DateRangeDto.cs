using System;
using System.Collections.Generic;

namespace Simulation.SimulationHub.Attribute.Dtos
{
    public class DateRangeDto
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public List<DateTimeOffset> Steps { get; set; }

        public DateRangeDto()
        {
            Steps = new List<DateTimeOffset>();
        }
    }
}