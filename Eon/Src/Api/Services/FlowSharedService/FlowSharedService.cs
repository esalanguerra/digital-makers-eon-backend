using Eon.Data.Interfaces.IFactories;
using Eon.Data.Interfaces.IRepositories;
using Eon.Data.Interfaces.IServices;
using Eon.DTOs.FlowDTO;

namespace Eon.Api.Services.FlowSharedService
{
    public class FlowSharedService : IFlowServiceInterface
    {
        private readonly IFlowRepositoryInterface _flowRepository;
        private readonly IFlowFactoryInterface _flowFactory;

        public FlowSharedService(IFlowRepositoryInterface flowRepository, IFlowFactoryInterface flowFactory)
        {
            _flowRepository = flowRepository;
            _flowFactory = flowFactory;
        }

        public FlowListResponseDTO GetAll()
        {
            var flows = _flowRepository.GetAll();
            var flowDtos = flows.Select(flow => new FlowViewModelDTO(flow.Id, flow.Name, flow.Folder));
            return new FlowListResponseDTO("Success", "200", flowDtos);
        }

        public SingleFlowResponseDTO? GetById(int id)
        {
            var flow = _flowRepository.GetById(id);
            if (flow == null)
            {
                return new SingleFlowResponseDTO("Flow not found", "404", null);
            }
            var flowDto = new FlowViewModelDTO(flow.Id, flow.Name, flow.Folder);
            return new SingleFlowResponseDTO("Success", "200", flowDto);
        }

        public SingleFlowResponseDTO? GetByName(string name)
        {
            var flow = _flowRepository.GetByName(name);
            if (flow == null)
            {
                return new SingleFlowResponseDTO("Flow not found", "404", null);
            }
            var flowDto = new FlowViewModelDTO(flow.Id, flow.Name, flow.Folder);
            return new SingleFlowResponseDTO("Success", "200", flowDto);
        }

        public SingleFlowResponseDTO Save(CreateFlowRequestDTO flowDto)
        {
            _flowFactory.ValidateCreateFlowRequest(flowDto);
            var flow = _flowFactory.CreateFlow(flowDto);
            var savedFlow = _flowRepository.Save(flow);
            var responseDto = new FlowViewModelDTO(savedFlow.Id, savedFlow.Name, savedFlow.Folder);
            return new SingleFlowResponseDTO("Flow created successfully", "201", responseDto);
        }

        public SingleFlowResponseDTO Update(int id, UpdateFlowRequestDTO flowDto)
        {
            _flowFactory.ValidateUpdateFlowRequest(flowDto);
            var existingFlow = _flowRepository.GetById(id);
            if (existingFlow == null)
            {
                return new SingleFlowResponseDTO("Flow not found", "404", null);
            }
            var updatedFlow = _flowFactory.UpdateFlow(existingFlow, flowDto);
            var savedFlow = _flowRepository.Update(id, updatedFlow);
            var responseDto = new FlowViewModelDTO(savedFlow.Id, savedFlow.Name, savedFlow.Folder);
            return new SingleFlowResponseDTO("Flow updated successfully", "200", responseDto);
        }

        public SingleFlowResponseDTO Delete(int id)
        {
            var deletedFlow = _flowRepository.Delete(id);
            if (deletedFlow == null)
            {
                return new SingleFlowResponseDTO("Flow not found", "404", null);
            }
            var responseDto = new FlowViewModelDTO(deletedFlow.Id, deletedFlow.Name, deletedFlow.Folder);
            return new SingleFlowResponseDTO("Flow deleted successfully", "200", responseDto);
        }
    }
}
