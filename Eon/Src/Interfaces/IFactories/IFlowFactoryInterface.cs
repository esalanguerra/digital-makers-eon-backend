using Eon.DTOs.FlowDTO;
using Eon.Data.Models.Flows;

namespace Eon.Data.Interfaces.IFactories
{
    public interface IFlowFactoryInterface
    {
        // Valida os dados fornecidos para criar um novo fluxo.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateCreateFlowRequest(CreateFlowRequestDTO dto);

        // Valida os dados fornecidos para atualizar um fluxo existente.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateUpdateFlowRequest(UpdateFlowRequestDTO dto);

        // Cria e retorna um objeto Flow com base nos dados fornecidos no CreateFlowRequestDTO.
        Flow CreateFlow(CreateFlowRequestDTO dto);

        // Atualiza um objeto Flow existente com base nos dados fornecidos no UpdateFlowRequestDTO.
        // Retorna o objeto Flow atualizado.
        Flow UpdateFlow(Flow existingFlow, UpdateFlowRequestDTO dto);
    }
}
