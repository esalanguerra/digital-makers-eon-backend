using Eon.Com.Domain.Models.Dto.TeamDto;
using Eon.Com.Domain.Models.Entity.TeamEntity;

namespace Eon.Com.Interfaces.Factories.TeamFactory
{
    public interface ITeamFactoryInterface
    {
        // Valida os dados fornecidos para a criação de um novo time.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateCreateTeamRequest(CreateTeamRequestDTO dto);

        // Valida os dados fornecidos para a atualização de um time existente.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateUpdateTeamRequest(UpdateTeamRequestDTO dto);

        // Cria um novo objeto Team com base nos dados fornecidos no CreateTeamRequestDTO.
        // Retorna o objeto Team criado.
        Team CreateTeam(CreateTeamRequestDTO dto);

        // Atualiza um objeto Team existente com base nos dados fornecidos no UpdateTeamRequestDTO.
        // Retorna o objeto Team atualizado.
        Team UpdateTeam(Team existingTeam, UpdateTeamRequestDTO dto);
    }
}
