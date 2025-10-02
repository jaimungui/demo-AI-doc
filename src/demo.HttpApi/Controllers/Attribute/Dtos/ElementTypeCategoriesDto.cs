using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.SimulationHub.Attribute.Dtos
{
    public class ElementTypeCategoriesDto
    {
        public string Type { get; set; }
        public List<AttributeMetadataDto> Categories { get; set; }
    }
}
