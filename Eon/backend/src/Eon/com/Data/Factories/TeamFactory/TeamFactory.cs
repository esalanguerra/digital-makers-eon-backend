using Eon.Com.Domain.Models.Dto.TeamDto;
using Eon.Com.Domain.Models.Entity.TeamEntity;
using Eon.Com.Interfaces.Factories.TeamFactory;

namespace Eon.Com.Data.Factories.TeamFactory
{
    /// <summary>
    /// Implementação da fábrica para criação e atualização de equipes.
    /// </summary>
    public class TeamFactory : ITeamFactoryInterface
    {
        /// <summary>
        /// Valida os dados fornecidos para criar uma nova equipe.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para criar a equipe.</param>
        public void ValidateCreateTeamRequest(CreateTeamRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo
            ValidateCreateTeam(dto);
        }

        /// <summary>
        /// Valida os dados fornecidos para atualizar uma equipe existente.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para atualizar a equipe.</param>
        public void ValidateUpdateTeamRequest(UpdateTeamRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo
            ValidateUpdateTeam(dto);
        }

        /// <summary>
        /// Método privado para validar os dados do CreateTeamRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para validação.</param>
        private void ValidateCreateTeam(CreateTeamRequestDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Name is required.", nameof(dto.Name)); // Valida que o nome não seja nulo ou em branco

            // Adicione outras validações conforme necessário
        }

        /// <summary>
        /// Método privado para validar os dados do UpdateTeamRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para validação.</param>
        private void ValidateUpdateTeam(UpdateTeamRequestDTO dto)
        {
            // Adicione validações conforme necessário, por exemplo, garantir que pelo menos um campo esteja presente
        }

        /// <summary>
        /// Cria um objeto Team a partir do CreateTeamRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para criar a equipe.</param>
        /// <returns>Um objeto Team criado a partir do DTO.</returns>
        public Team CreateTeam(CreateTeamRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo

            return new Team
            {
                Name = dto.Name,
                Description = dto.Description
            };
        }

        /// <summary>
        /// Atualiza um objeto Team existente com base no UpdateTeamRequestDTO.
        /// </summary>
        /// <param name="existingTeam">A equipe existente a ser atualizada.</param>
        /// <param name="dto">O DTO contendo os dados de atualização.</param>
        /// <returns>O objeto Team atualizado.</returns>
        public Team UpdateTeam(Team existingTeam, UpdateTeamRequestDTO dto)
        {
            if (existingTeam == null) throw new ArgumentNullException(nameof(existingTeam)); // Garante que a equipe não seja nula
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo

            // Atualiza as propriedades da equipe com base nos valores não nulos do DTO
            existingTeam.Name = string.IsNullOrEmpty(dto.Name) ? existingTeam.Name : dto.Name;
            existingTeam.Description = string.IsNullOrEmpty(dto.Description) ? existingTeam.Description : dto.Description;

            return existingTeam;
        }
    }
}
