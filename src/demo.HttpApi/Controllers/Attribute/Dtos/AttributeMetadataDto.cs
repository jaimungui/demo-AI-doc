using System.Collections.Generic;

namespace Simulation.SimulationHub.Attribute.Dtos;

public class AttributeMetadataDto
{
    public string Name { get; set; }
    public List<AttributeInfoDto> Attributes { get; set; }
}
