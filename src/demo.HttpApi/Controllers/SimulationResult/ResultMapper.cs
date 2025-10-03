using AutoMapper;
using Simulation.SimulationHub.SimulationResult.Dtos;
using Simulation.SimulationHub.SimulationResult.Staging;
using Simulation.SimulationHub.SimulationResult.UpdateScenarioStatus;
using System.Collections.Generic;

namespace Simulation.SimulationHub.SimulationResult;

public class ResultMapper : Profile
{
    public ResultMapper()
    {
        MapScenarioSettings();
        MapSimulationSettings();
        MapSnapshot();
        MapScenario();
    }

    private void MapSnapshot()
    {
        CreateMap<Snapshot, SnapshotDto>();
    }

    private void MapScenario()
    {
        CreateMap<UpdateScenarioStatusDto, UpdateScenarioStatusCmd>();
    }

    private void MapSimulationSettings()
    {
        CreateMap<SimulationSettingsDto, SimulationSettingsCmd>();
        CreateMap<SimulationSettingsCmdResponse, SimulationSettingsResponseDto>();
    }

    private void MapScenarioSettings()
    {
        CreateMap<ScenarioSettingsDto, ScenarioSettingsCmd>()
            .ForMember(dest => dest.ExecutionId, src => src.Ignore());

        CreateMap<NetworkElementTypeDto, StagingTypeConfigurationParameterData>();

        CreateMap<ConfigurationParameterDataDto, StagingConfigurationParameterData>();

        CreateMap<PhysTypeDto, PhysTypeStaging>();

        CreateMap<ResultObjectRequestDto, ResultObjectRequestCmd>();

        CreateMap<ResultObjectDto, StagingResultObject>()
            .ForMember(dest => dest.Results, map => map.MapFrom<TranformResults>());

        CreateMap<ScenarioSettingsCmdResponse, ScenarioSettingsResponseDto>();
    }


    public class TranformResults : IValueResolver<ResultObjectDto, StagingResultObject, Dictionary<string, StagingTimeSerieData>>
    {
        public Dictionary<string, StagingTimeSerieData> Resolve(ResultObjectDto source, StagingResultObject destination, Dictionary<string, StagingTimeSerieData> destMember, ResolutionContext context)
        {
            var result = new Dictionary<string, StagingTimeSerieData>();
            foreach (var resObj in source.Results)
            {
                var aux = new StagingTimeSerieData();
                result[resObj.Key] = aux;
                foreach (var ts in resObj.Value)
                {
                    aux[ts.Key] = ts.Value;
                }
            }

            return result;
        }
    }
}

