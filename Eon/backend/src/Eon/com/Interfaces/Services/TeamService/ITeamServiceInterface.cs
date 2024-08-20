using Eon.Com.Api.ActionResults.ApiResponseData.TeamApiResponseData;
using Eon.Com.Domain.Models.Dto.TeamDto;

namespace Eon.Com.Interfaces.Services.TeamService
{
    public interface ITeamServiceInterface
    {
        // Retorna uma coleção de times encapsulada em um DTO com mensagem e código.
        // O DTO TeamListResponse contém a lista de times e informações adicionais, como mensagens de status.
        TeamListResponse GetAll();

        // Retorna um único time com base no ID.
        // O retorno é encapsulado em um DTO SingleTeamResponse com mensagem e código de status.
        // Se o time não for encontrado, pode retornar nulo.
        SingleTeamResponse? GetById(int id);

        // Retorna um único time com base no nome.
        // O retorno é encapsulado em um DTO SingleTeamResponse com mensagem e código de status.
        // Se o time não for encontrado, pode retornar nulo.
        SingleTeamResponse? GetByName(string name);

        // Cria um novo time com base nos dados fornecidos no DTO CreateTeamRequestDTO.
        // Retorna um DTO SingleTeamResponse com mensagem e código de status, indicando sucesso ou falha.
        SingleTeamResponse? Save(CreateTeamRequestDTO teamDto);

        // Atualiza um time existente com base no ID e nos dados fornecidos no DTO UpdateTeamRequestDTO.
        // Retorna um DTO SingleTeamResponse com mensagem e código de status, indicando sucesso ou falha.
        SingleTeamResponse? Update(int id, UpdateTeamRequestDTO teamDto);

        // Deleta um time com base no ID.
        // Retorna um DTO SingleTeamResponse com mensagem e código de status, indicando sucesso ou falha.
        // Se o time não for encontrado, pode retornar nulo.
        SingleTeamResponse? Delete(int id);
    }
}
