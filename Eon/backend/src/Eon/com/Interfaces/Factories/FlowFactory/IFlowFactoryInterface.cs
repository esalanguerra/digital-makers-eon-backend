using Eon.Com.Domain.Models.Dto.FlowDto;
using Eon.Com.Domain.Models.Entity.FlowEntity;

namespace Eon.Com.Interfaces.Factories.FlowFactory
{
    public interface IFlowFactoryInterface
    {
        // Valida os dados fornecidos para a criação de um novo fluxo.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateCreateFlowRequest(CreateFlowRequestDTO dto);

        // Valida os dados fornecidos para a atualização de um fluxo existente.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateUpdateFlowRequest(UpdateFlowRequestDTO dto);

        // Cria um novo objeto Flow com base nos dados fornecidos no CreateFlowRequestDTO.
        // Retorna o objeto Flow criado.
        Flow CreateFlow(CreateFlowRequestDTO dto);

        // Atualiza um objeto Flow existente com base nos dados fornecidos no UpdateFlowRequestDTO.
        // Retorna o objeto Flow atualizado.
        Flow UpdateFlow(Flow existingFlow, UpdateFlowRequestDTO dto);
    }
}
