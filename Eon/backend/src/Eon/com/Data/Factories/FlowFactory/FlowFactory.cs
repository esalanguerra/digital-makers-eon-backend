using Eon.Com.Domain.Models.Dto.FlowDto;
using Eon.Com.Domain.Models.Entity.FlowEntity;
using Eon.Com.Interfaces.Factories.FlowFactory;

namespace Eon.Com.Data.Factories.FlowFactory
{
    /// <summary>
    /// Implementação da fábrica para criação e atualização de fluxos.
    /// </summary>
    public class FlowFactory : IFlowFactoryInterface
    {
        /// <summary>
        /// Valida os dados fornecidos para criar um novo fluxo.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para criar o fluxo.</param>
        public void ValidateCreateFlowRequest(CreateFlowRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo
            ValidateCreateFlow(dto);
        }

        /// <summary>
        /// Valida os dados fornecidos para atualizar um fluxo existente.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para atualizar o fluxo.</param>
        public void ValidateUpdateFlowRequest(UpdateFlowRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo
            ValidateUpdateFlow(dto);
        }

        /// <summary>
        /// Método privado para validar os dados do CreateFlowRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para validação.</param>
        private void ValidateCreateFlow(CreateFlowRequestDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Name is required.", nameof(dto.Name)); // Valida que o nome não seja nulo ou em branco

            if (dto.FolderId <= 0)
                throw new ArgumentException("FolderId must be greater than zero.", nameof(dto.FolderId)); // Valida que FolderId seja um valor válido
        }

        /// <summary>
        /// Método privado para validar os dados do UpdateFlowRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para validação.</param>
        private void ValidateUpdateFlow(UpdateFlowRequestDTO dto)
        {
            // Adicione validações conforme necessário, por exemplo, garantir que pelo menos um campo esteja presente
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            ValidateUpdateFlow(dto);
        }

        /// <summary>
        /// Cria um objeto Flow a partir do CreateFlowRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para criar o fluxo.</param>
        /// <returns>Um objeto Flow criado a partir do DTO.</returns>
        public Flow CreateFlow(CreateFlowRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo

            return new Flow
            {
                Name = dto.Name,
                FolderId = dto.FolderId
            };
        }

        /// <summary>
        /// Atualiza um objeto Flow existente com base no UpdateFlowRequestDTO.
        /// </summary>
        /// <param name="existingFlow">O fluxo existente a ser atualizado.</param>
        /// <param name="dto">O DTO contendo os dados de atualização.</param>
        /// <returns>O objeto Flow atualizado.</returns>
        public Flow UpdateFlow(Flow existingFlow, UpdateFlowRequestDTO dto)
        {
            if (existingFlow == null) throw new ArgumentNullException(nameof(existingFlow)); // Garante que o fluxo não seja nulo
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo

            // Atualiza as propriedades do fluxo com base nos valores não nulos do DTO
            existingFlow.Name = !string.IsNullOrWhiteSpace(dto.Name) ? dto.Name : existingFlow.Name;
            existingFlow.FolderId = (int)(dto.FolderId > 0 ? dto.FolderId : existingFlow.FolderId);

            return existingFlow;
        }
    }
}
