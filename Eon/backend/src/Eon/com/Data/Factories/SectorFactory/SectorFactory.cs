using Eon.Com.Domain.Models.Dto.SectorDto;
using Eon.Com.Domain.Models.Entity.SectorEntity;
using Eon.Com.Interfaces.Factories.SectorFactory;

namespace Eon.Com.Data.Factories.SectorFactory
{
    /// <summary>
    /// Implementação da fábrica para criação e atualização de setores.
    /// </summary>
    public class SectorFactory : ISectorFactoryInterface
    {
        /// <summary>
        /// Valida os dados fornecidos para criar um novo setor.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para criar o setor.</param>
        public void ValidateCreateSectorRequest(CreateSectorRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo
            ValidateCreateSector(dto);
        }

        /// <summary>
        /// Valida os dados fornecidos para atualizar um setor existente.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para atualizar o setor.</param>
        public void ValidateUpdateSectorRequest(UpdateSectorRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo
            ValidateUpdateSector(dto);
        }

        /// <summary>
        /// Método privado para validar os dados do CreateSectorRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para validação.</param>
        private void ValidateCreateSector(CreateSectorRequestDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Name is required.", nameof(dto.Name)); // Valida que o nome não seja nulo ou em branco

            // Adicione outras validações conforme necessário
        }

        /// <summary>
        /// Método privado para validar os dados do UpdateSectorRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para validação.</param>
        private void ValidateUpdateSector(UpdateSectorRequestDTO dto)
        {
            // Adicione validações conforme necessário, por exemplo, garantir que pelo menos um campo esteja presente
        }

        /// <summary>
        /// Cria um objeto Sector a partir do CreateSectorRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para criar o setor.</param>
        /// <returns>Um objeto Sector criado a partir do DTO.</returns>
        public Sector CreateSector(CreateSectorRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo

            return new Sector
            {
                Name = dto.Name,
                Description = dto.Description,
                UserBusinessId = dto.UserBusinessId,
                // A inicialização de UserBusiness pode ser tratada separadamente, se necessário
            };
        }

        /// <summary>
        /// Atualiza um objeto Sector existente com base no UpdateSectorRequestDTO.
        /// </summary>
        /// <param name="existingSector">O setor existente a ser atualizado.</param>
        /// <param name="dto">O DTO contendo os dados de atualização.</param>
        /// <returns>O objeto Sector atualizado.</returns>
        public Sector UpdateSector(Sector existingSector, UpdateSectorRequestDTO dto)
        {
            if (existingSector == null) throw new ArgumentNullException(nameof(existingSector)); // Garante que o setor não seja nulo
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo

            // Atualiza as propriedades do setor com base nos valores não nulos do DTO
            existingSector.Name = string.IsNullOrEmpty(dto.Name) ? existingSector.Name : dto.Name;
            existingSector.Description = string.IsNullOrEmpty(dto.Description) ? existingSector.Description : dto.Description;
            existingSector.UserBusinessId = dto.UserBusinessId ?? existingSector.UserBusinessId;

            return existingSector;
        }
    }
}
