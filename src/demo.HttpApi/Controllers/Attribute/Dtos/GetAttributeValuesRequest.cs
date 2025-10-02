using System;
using System.Collections.Generic;

namespace Simulation.SimulationHub.Attribute.Dtos
{
    public record GetAttributeValuesRequest(Guid ScenarioId, Guid NetworkElementId, DateTime StartDate, DateTime EndDate,
        string Category, List<string> AttributeNames);
}
