using System;

namespace Simulation.SimulationHub.Attribute.Dtos
{
    public class AttributeDto
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTimeOffset ResultDateTime { get; set; }
    }
}