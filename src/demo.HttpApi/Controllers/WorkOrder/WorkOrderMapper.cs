using AutoMapper;
using Simulation.SimulationHub.WorkOrder.Dtos;

namespace Simulation.SimulationHub.WorkOrder;

public class WorkOrderMapper : Profile
{
	public WorkOrderMapper()
	{
		CreateMap<WorkOrderDto, WorkOrderResponseDto>();
		CreateMap<WorkOrder, WorkOrderDto>();
        CreateMap<AddWorkOrderDto, WorkOrder>();
		CreateMap<WorkOrderElement, WorkOrderElementDto>();
        CreateMap<WorkOrderElementDto, WorkOrderElementResponseDto>();
    }
}
