using Eon.Com.Domain.Models.Dto.FolderDto;
using Eon.Com.Domain.Models.Entity.FolderEntity;
using Eon.Com.Interfaces.Factories.FolderFactory;

namespace Eon.Com.Data.Factories.FolderFactory
{
    /// <summary>
    /// Implementação da fábrica para criação e atualização de pastas.
    /// </summary>
    public class FolderFactory : IFolderFactoryInterface
    {
        /// <summary>
        /// Valida os dados fornecidos para criar uma nova pasta.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para criar a pasta.</param>
        public void ValidateCreateFolderRequest(CreateFolderRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo
            ValidateCreateFolder(dto);
        }

        /// <summary>
        /// Valida os dados fornecidos para atualizar uma pasta existente.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para atualizar a pasta.</param>
        public void ValidateUpdateFolderRequest(UpdateFolderRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo
            ValidateUpdateFolder(dto);
        }

        /// <summary>
        /// Método privado para validar os dados do CreateFolderRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para validação.</param>
        private void ValidateCreateFolder(CreateFolderRequestDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Name is required.", nameof(dto.Name)); // Valida que o nome não seja nulo ou em branco

            // Adicione outras validações conforme necessário
        }

        /// <summary>
        /// Método privado para validar os dados do UpdateFolderRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para validação.</param>
        private void ValidateUpdateFolder(UpdateFolderRequestDTO dto)
        {
            // Adicione validações conforme necessário, por exemplo, garantir que pelo menos um campo esteja presente
        }

        /// <summary>
        /// Cria um objeto Folder a partir do CreateFolderRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para criar a pasta.</param>
        /// <returns>Um objeto Folder criado a partir do DTO.</returns>
        public Folder CreateFolder(CreateFolderRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo

            return new Folder
            {
                Name = dto.Name,
                SectorId = dto.SectorId
            };
        }

        /// <summary>
        /// Atualiza um objeto Folder existente com base no UpdateFolderRequestDTO.
        /// </summary>
        /// <param name="existingFolder">A pasta existente a ser atualizada.</param>
        /// <param name="dto">O DTO contendo os dados de atualização.</param>
        /// <returns>O objeto Folder atualizado.</returns>
        public Folder UpdateFolder(Folder existingFolder, UpdateFolderRequestDTO dto)
        {
            if (existingFolder == null) throw new ArgumentNullException(nameof(existingFolder)); // Garante que a pasta não seja nula
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo

            // Atualiza as propriedades da pasta com base nos valores não nulos do DTO
            existingFolder.Name = string.IsNullOrEmpty(dto.Name) ? existingFolder.Name : dto.Name;
            existingFolder.SectorId = dto.SectorId.HasValue ? dto.SectorId.Value : existingFolder.SectorId;

            return existingFolder;
        }
    }
}
