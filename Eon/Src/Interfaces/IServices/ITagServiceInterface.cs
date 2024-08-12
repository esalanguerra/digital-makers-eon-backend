using Eon.DTOs.TagDTO;

namespace Eon.Data.Interfaces.IServices
{
    public interface ITagServiceInterface
    {
        // Retorna uma coleção de tags encapsulada em um DTO com mensagem e código
        TagListResponseDTO GetAll();

        // Retorna uma tag única com base no ID encapsulada em um DTO com mensagem e código, ou nulo se não encontrada
        SingleTagResponseDTO? GetById(int id);

        // Retorna uma tag única com base no nome encapsulada em um DTO com mensagem e código, ou nulo se não encontrada
        SingleTagResponseDTO? GetByName(string name);

        // Cria uma nova tag com base nos dados fornecidos e retorna um DTO com mensagem e código
        SingleTagResponseDTO? Save(CreateTagRequestDTO tagDto);

        // Atualiza uma tag existente com base no ID e nos dados fornecidos, retornando um DTO com mensagem e código
        SingleTagResponseDTO? Update(int id, UpdateTagRequestDTO tagDto);

        // Deleta uma tag com base no ID e retorna um DTO com mensagem e código, ou nulo se não encontrada
        SingleTagResponseDTO? Delete(int id);
    }
}
