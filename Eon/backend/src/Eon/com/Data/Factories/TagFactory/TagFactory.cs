using Eon.Com.Domain.Models.Dto.TagDto;
using Eon.Com.Domain.Models.Entity.TagEntity;
using Eon.Com.Interfaces.Factories.TagFactory;

namespace Eon.Com.Data.Factories.TagFactory
{
    /// <summary>
    /// Implementação da fábrica para criação e atualização de etiquetas.
    /// </summary>
    public class TagFactory : ITagFactoryInterface
    {
        /// <summary>
        /// Valida os dados fornecidos para criar uma nova etiqueta.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para criar a etiqueta.</param>
        public void ValidateCreateTagRequest(CreateTagRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo
            ValidateCreateTag(dto);
        }

        /// <summary>
        /// Valida os dados fornecidos para atualizar uma etiqueta existente.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para atualizar a etiqueta.</param>
        public void ValidateUpdateTagRequest(UpdateTagRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo
            ValidateUpdateTag(dto);
        }

        /// <summary>
        /// Método privado para validar os dados do CreateTagRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para validação.</param>
        private void ValidateCreateTag(CreateTagRequestDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Name is required.", nameof(dto.Name)); // Valida que o nome não seja nulo ou em branco

            // Adicione outras validações conforme necessário
        }

        /// <summary>
        /// Método privado para validar os dados do UpdateTagRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para validação.</param>
        private void ValidateUpdateTag(UpdateTagRequestDTO dto)
        {
            // Adicione validações conforme necessário, por exemplo, garantir que pelo menos um campo esteja presente
        }

        /// <summary>
        /// Cria um objeto Tag a partir do CreateTagRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para criar a etiqueta.</param>
        /// <returns>Um objeto Tag criado a partir do DTO.</returns>
        public Tag CreateTag(CreateTagRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo

            return new Tag
            {
                Name = dto.Name,
                Description = dto.Description,
                SectorId = dto.SectorId
            };
        }

        /// <summary>
        /// Atualiza um objeto Tag existente com base no UpdateTagRequestDTO.
        /// </summary>
        /// <param name="existingTag">A etiqueta existente a ser atualizada.</param>
        /// <param name="dto">O DTO contendo os dados de atualização.</param>
        /// <returns>O objeto Tag atualizado.</returns>
        public Tag UpdateTag(Tag existingTag, UpdateTagRequestDTO dto)
        {
            if (existingTag == null) throw new ArgumentNullException(nameof(existingTag)); // Garante que a etiqueta não seja nula
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo

            // Atualiza as propriedades da etiqueta com base nos valores não nulos do DTO
            existingTag.Name = string.IsNullOrEmpty(dto.Name) ? existingTag.Name : dto.Name;
            existingTag.Description = string.IsNullOrEmpty(dto.Description) ? existingTag.Description : dto.Description;
            existingTag.SectorId = dto.SectorId ?? existingTag.SectorId; // Atualiza o SectorId se estiver presente

            return existingTag;
        }
    }
}
