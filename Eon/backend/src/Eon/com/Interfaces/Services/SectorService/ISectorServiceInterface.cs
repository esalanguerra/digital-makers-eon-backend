using Eon.Com.Api.ActionResults.ApiResponseData.SectorApiResponseData;
using Eon.Com.Domain.Models.Dto.SectorDto;

namespace Eon.Com.Interfaces.Services.SectorService
{
    public interface ISectorServiceInterface
    {
        // Retorna uma coleção de setores encapsulada em um DTO com mensagem e código.
        // O DTO SectorListResponse contém a lista de setores e informações adicionais, como mensagens de status.
        SectorListResponse GetAll();

        // Retorna um único setor com base no ID.
        // O retorno é encapsulado em um DTO SingleSectorResponse com mensagem e código de status.
        // Se o setor não for encontrado, pode retornar nulo.
        SingleSectorResponse? GetById(int id);

        // Retorna um único setor com base no nome.
        // O retorno é encapsulado em um DTO SingleSectorResponse com mensagem e código de status.
        // Se o setor não for encontrado, pode retornar nulo.
        SingleSectorResponse? GetByName(string name);

        // Cria um novo setor com base nos dados fornecidos no DTO CreateSectorRequestDTO.
        // Retorna um DTO SingleSectorResponse com mensagem e código de status, indicando sucesso ou falha.
        SingleSectorResponse? Save(CreateSectorRequestDTO sectorDto);

        // Atualiza um setor existente com base no ID e nos dados fornecidos no DTO UpdateSectorRequestDTO.
        // Retorna um DTO SingleSectorResponse com mensagem e código de status, indicando sucesso ou falha.
        SingleSectorResponse? Update(int id, UpdateSectorRequestDTO sectorDto);

        // Deleta um setor com base no ID.
        // Retorna um DTO SingleSectorResponse com mensagem e código de status, indicando sucesso ou falha.
        // Se o setor não for encontrado, pode retornar nulo.
        SingleSectorResponse? Delete(int id);
    }
}
