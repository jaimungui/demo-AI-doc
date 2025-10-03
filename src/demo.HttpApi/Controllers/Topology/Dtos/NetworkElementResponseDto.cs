using System;

namespace Simulation.SimulationHub.Topology
{
    public class NetworkElementResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double[] Centroid { get; set; }
    }
}