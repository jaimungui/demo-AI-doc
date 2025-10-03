namespace Simulation.SimulationHub.SimulationResult.Dtos;

public class ConfigurationParameterDataDto
{
    public string Name { get; set; }
    public string Alias { get; set; }
    public string Group { get; set; }
    public string Type { get; set; }
    public PhysTypeDto PhysType { get; set; }
    public bool IsWeb { get; set; }

}
