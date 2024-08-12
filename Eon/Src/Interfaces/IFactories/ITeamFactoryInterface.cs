using Eon.DTOs.TeamDTO;
using Eon.Data.Models.Teams;

namespace Eon.Data.Interfaces.IFactories
{
    public interface ITeamFactoryInterface
    {
        // Valida os dados fornecidos para criar um novo time.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateCreateTeamRequest(CreateTeamRequestDTO dto);

        // Valida os dados fornecidos para atualizar um time existente.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateUpdateTeamRequest(UpdateTeamRequestDTO dto);

        // Cria e retorna um objeto Team com base nos dados fornecidos no CreateTeamRequestDTO.
        Team CreateTeam(CreateTeamRequestDTO dto);

        // Atualiza um objeto Team existente com base nos dados fornecidos no UpdateTeamRequestDTO.
        // Retorna o objeto Team atualizado.
        Team UpdateTeam(Team existingTeam, UpdateTeamRequestDTO dto);
    }
}
