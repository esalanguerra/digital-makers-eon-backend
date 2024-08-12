using Eon.DTOs.TokenDTO;

namespace Eon.Data.Interfaces.IServices
{
    public interface ITokenServiceInterface
    {
        // Retorna uma coleção de tokens encapsulada em um DTO com mensagem e código
        TokenListResponseDTO GetAll();

        // Retorna um token único com base no ID encapsulado em um DTO com mensagem e código, ou nulo se não encontrado
        SingleTokenResponseDTO? GetById(int id);

        // Cria um novo token com base nos dados fornecidos e retorna um DTO com mensagem e código
        SingleTokenResponseDTO? Save(CreateTokenRequestDTO tokenDto);

        // Atualiza um token existente com base no ID e nos dados fornecidos, retornando um DTO com mensagem e código
        SingleTokenResponseDTO? Update(int id, UpdateTokenRequestDTO tokenDto);

        // Deleta um token com base no ID e retorna um DTO com mensagem e código, ou nulo se não encontrado
        SingleTokenResponseDTO? Delete(int id);
    }
}
