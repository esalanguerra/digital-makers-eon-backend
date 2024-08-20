using Eon.Com.Domain.Models.Dto.FlowSharedDto;
using Eon.Com.Domain.Models.Entity.FlowSharedEntity;

namespace Eon.Com.Interfaces.Factories.FlowSharedFactory
{
    public interface IFlowSharedFactoryInterface
    {
        /// <summary>
        /// Valida os dados fornecidos para a criação de um novo fluxo compartilhado.
        /// Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        /// </summary>
        void ValidateCreateFlowSharedRequest(CreateFlowSharedRequestDTO dto);

        /// <summary>
        /// Valida os dados fornecidos para a atualização de um fluxo compartilhado existente.
        /// Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        /// </summary>
        void ValidateUpdateFlowSharedRequest(UpdateFlowSharedRequestDTO dto);

        /// <summary>
        /// Cria um novo fluxo compartilhado com base nos dados fornecidos no CreateFlowSharedRequestDTO.
        /// </summary>
        /// <param name="dto">Dados do novo fluxo compartilhado.</param>
        /// <returns>Objeto FlowShared criado.</returns>
        FlowShared CreateFlowShared(CreateFlowSharedRequestDTO dto);

        /// <summary>
        /// Atualiza um fluxo compartilhado existente com base nos dados fornecidos no UpdateFlowSharedRequestDTO.
        /// </summary>
        /// <param name="existingFlowShared">Fluxo compartilhado existente a ser atualizado.</param>
        /// <param name="dto">Dados de atualização do fluxo compartilhado.</param>
        /// <returns>Fluxo compartilhado atualizado.</returns>
        FlowShared UpdateFlowShared(FlowShared existingFlowShared, UpdateFlowSharedRequestDTO dto);
    }
}
