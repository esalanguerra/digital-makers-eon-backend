using Eon.DTOs.FlowSharedDTO;
using Eon.Data.Interfaces.IFactories;
using Eon.Data.Models.Flows;

namespace Eon.Data.Factories
{
    public class FlowSharedFactory : IFlowSharedFactoryInterface
    {
        public void ValidateCreateFlowSharedRequest(CreateFlowSharedRequestDTO dto)
        {
            ValidateCreateFlowShared(dto);
        }

        public void ValidateUpdateFlowSharedRequest(UpdateFlowSharedRequestDTO dto)
        {
            ValidateUpdateFlowShared(dto);
        }

        private void ValidateCreateFlowShared(CreateFlowSharedRequestDTO dto)
        {
            if (dto.FlowId <= 0)
                throw new ArgumentException("FlowId is required.");

            if (dto.UserId <= 0)
                throw new ArgumentException("UserId is required.");

            if (string.IsNullOrEmpty(dto.Link))
                throw new ArgumentException("Link is required.");
        }

        private void ValidateUpdateFlowShared(UpdateFlowSharedRequestDTO dto)
        {
            if (dto.FlowId <= 0)
                throw new ArgumentException("FlowId is required.");

            if (dto.UserId <= 0)
                throw new ArgumentException("UserId is required.");

            if (string.IsNullOrEmpty(dto.Link))
                throw new ArgumentException("Link is required.");
        }

        public FlowShared CreateFlowShared(CreateFlowSharedRequestDTO dto)
        {
            return new FlowShared
            {
                FlowId = dto.FlowId,
                UserId = dto.UserId,
                Link = dto.Link,
                Status = dto.Status
            };
        }

        public FlowShared UpdateFlowShared(FlowShared existingFlowShared, UpdateFlowSharedRequestDTO dto)
        {
            existingFlowShared.FlowId = (int)dto.FlowId;
            existingFlowShared.UserId = (int)dto.UserId;
            existingFlowShared.Link = dto.Link;
            existingFlowShared.Status = (bool)dto.Status;
            return existingFlowShared;
        }
    }
}
