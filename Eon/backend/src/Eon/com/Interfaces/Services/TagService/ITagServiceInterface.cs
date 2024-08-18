using Eon.Com.Api.ActionResults.ApiResponseData.TagApiResponseData;
using Eon.Com.Domain.Models.Dto.TagDto;

namespace Eon.Com.Interfaces.Services.TagService
{
    public interface ITagServiceInterface
    {
        // Retorna uma coleção de etiquetas encapsulada em um DTO com mensagem e código.
        // O DTO TagListResponse contém a lista de etiquetas e informações adicionais, como mensagens de status.
        TagListResponse GetAll();

        // Retorna uma única etiqueta com base no ID.
        // O retorno é encapsulado em um DTO SingleTagResponse com mensagem e código de status.
        // Se a etiqueta não for encontrada, pode retornar nulo.
        SingleTagResponse? GetById(int id);

        // Retorna uma única etiqueta com base no nome.
        // O retorno é encapsulado em um DTO SingleTagResponse com mensagem e código de status.
        // Se a etiqueta não for encontrada, pode retornar nulo.
        SingleTagResponse? GetByName(string name);

        // Cria uma nova etiqueta com base nos dados fornecidos no DTO CreateTagRequestDTO.
        // Retorna um DTO SingleTagResponse com mensagem e código de status, indicando sucesso ou falha.
        SingleTagResponse? Save(CreateTagRequestDTO tagDto);

        // Atualiza uma etiqueta existente com base no ID e nos dados fornecidos no DTO UpdateTagRequestDTO.
        // Retorna um DTO SingleTagResponse com mensagem e código de status, indicando sucesso ou falha.
        SingleTagResponse? Update(int id, UpdateTagRequestDTO tagDto);

        // Deleta uma etiqueta com base no ID.
        // Retorna um DTO SingleTagResponse com mensagem e código de status, indicando sucesso ou falha.
        // Se a etiqueta não for encontrada, pode retornar nulo.
        SingleTagResponse? Delete(int id);
    }
}
