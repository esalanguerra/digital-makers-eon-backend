using Eon.Data.Interfaces.IFactories;
using Eon.Data.Models.Flows;
using Eon.DTOs.FlowDTO;

namespace Eon.Data.Factories
{
    public class FlowFactory : IFlowFactoryInterface
    {
        public void ValidateCreateFlowRequest(CreateFlowRequestDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Name))
                throw new ArgumentException("Flow name is required.");
            if (string.IsNullOrEmpty(dto.Folder))
                throw new ArgumentException("Folder name is required.");
        }

        public void ValidateUpdateFlowRequest(UpdateFlowRequestDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Name))
                throw new ArgumentException("Flow name is required.");
            if (string.IsNullOrEmpty(dto.Folder))
                throw new ArgumentException("Folder name is required.");
        }

        public Flow CreateFlow(CreateFlowRequestDTO dto)
        {
            return new Flow(dto.Name, dto.Folder);
        }

        public Flow UpdateFlow(Flow existingFlow, UpdateFlowRequestDTO dto)
        {
            existingFlow.Name = dto.Name;
            existingFlow.Folder = dto.Folder;
            return existingFlow;
        }
    }
}
