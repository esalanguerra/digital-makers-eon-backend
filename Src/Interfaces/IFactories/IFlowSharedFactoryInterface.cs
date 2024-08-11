using Eon.DTOs.FlowSharedDTO;
using Eon.Data.Models.Flows;

namespace Eon.Data.Interfaces.IFactories
{
    public interface IFlowSharedFactoryInterface
    {
        // Valida os dados fornecidos para criar um novo fluxo compartilhado.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateCreateFlowSharedRequest(CreateFlowSharedRequestDTO dto);

        // Valida os dados fornecidos para atualizar um fluxo compartilhado existente.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateUpdateFlowSharedRequest(UpdateFlowSharedRequestDTO dto);

        // Cria e retorna um objeto FlowShared com base nos dados fornecidos no CreateFlowSharedRequestDTO.
        FlowShared CreateFlowShared(CreateFlowSharedRequestDTO dto);

        // Atualiza um objeto FlowShared existente com base nos dados fornecidos no UpdateFlowSharedRequestDTO.
        // Retorna o objeto FlowShared atualizado.
        FlowShared UpdateFlowShared(FlowShared existingFlowShared, UpdateFlowSharedRequestDTO dto);
    }
}
