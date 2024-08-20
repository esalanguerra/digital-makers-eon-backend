using Eon.Com.Domain.Models.Dto.FlowSharedDto;
using Eon.Com.Domain.Models.Entity.FlowSharedEntity;
using Eon.Com.Interfaces.Factories.FlowSharedFactory;

namespace Eon.Com.Data.Factories.FlowSharedFactory
{
    /// <summary>
    /// Implementação da fábrica para criação e atualização de fluxos compartilhados.
    /// </summary>
    public class FlowSharedFactory : IFlowSharedFactoryInterface
    {
        /// <summary>
        /// Valida os dados fornecidos para criar um novo fluxo compartilhado.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para criar o fluxo compartilhado.</param>
        public void ValidateCreateFlowSharedRequest(CreateFlowSharedRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo
            ValidateCreateFlowShared(dto);
        }

        /// <summary>
        /// Valida os dados fornecidos para atualizar um fluxo compartilhado existente.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para atualizar o fluxo compartilhado.</param>
        public void ValidateUpdateFlowSharedRequest(UpdateFlowSharedRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo
            ValidateUpdateFlowShared(dto);
        }

        /// <summary>
        /// Método privado para validar os dados do CreateFlowSharedRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para validação.</param>
        private void ValidateCreateFlowShared(CreateFlowSharedRequestDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Link))
                throw new ArgumentException("Link is required.", nameof(dto.Link)); // Valida que o link não seja nulo ou em branco

            // Adicione outras validações conforme necessário
        }

        /// <summary>
        /// Método privado para validar os dados do UpdateFlowSharedRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para validação.</param>
        private void ValidateUpdateFlowShared(UpdateFlowSharedRequestDTO dto)
        {
            // Adicione validações conforme necessário, por exemplo, garantir que pelo menos um campo esteja presente
        }

        /// <summary>
        /// Cria um objeto FlowShared a partir do CreateFlowSharedRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para criar o fluxo compartilhado.</param>
        /// <returns>Um objeto FlowShared criado a partir do DTO.</returns>
        public FlowShared CreateFlowShared(CreateFlowSharedRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo

            return new FlowShared
            {
                FlowId = dto.FlowId,
                UserId = dto.UserId,
                Link = dto.Link,
                Status = dto.Status
            };
        }

        /// <summary>
        /// Atualiza um objeto FlowShared existente com base no UpdateFlowSharedRequestDTO.
        /// </summary>
        /// <param name="existingFlowShared">O fluxo compartilhado existente a ser atualizado.</param>
        /// <param name="dto">O DTO contendo os dados de atualização.</param>
        /// <returns>O objeto FlowShared atualizado.</returns>
        public FlowShared UpdateFlowShared(FlowShared existingFlowShared, UpdateFlowSharedRequestDTO dto)
        {
            if (existingFlowShared == null) throw new ArgumentNullException(nameof(existingFlowShared)); // Garante que o fluxo compartilhado não seja nulo
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo

            // Atualiza as propriedades do fluxo compartilhado com base nos valores não nulos do DTO
            existingFlowShared.FlowId = (int)(dto.FlowId != 0 ? dto.FlowId : existingFlowShared.FlowId);
            existingFlowShared.UserId = (int)(dto.UserId != 0 ? dto.UserId : existingFlowShared.UserId);
            existingFlowShared.Link = string.IsNullOrEmpty(dto.Link) ? existingFlowShared.Link : dto.Link;
            existingFlowShared.Status = (bool)(dto.Status != default ? dto.Status : existingFlowShared.Status);

            return existingFlowShared;
        }
    }
}
