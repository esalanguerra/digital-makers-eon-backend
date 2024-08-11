using Eon.DTOs.SectorDTO;

namespace Eon.Data.Interfaces.IServices
{
    public interface ISectorServiceInterface
    {
        // Retorna uma coleção de setores encapsulada em um DTO com mensagem e código
        SectorListResponseDTO GetAll();

        // Retorna um setor único com base no ID encapsulado em um DTO com mensagem e código, ou nulo se não encontrado
        SingleSectorResponseDTO? GetById(int id);

        // Retorna um setor único com base na descrição encapsulada em um DTO com mensagem e código, ou nulo se não encontrado
        SingleSectorResponseDTO? GetByDescription(string description);

        // Cria um novo setor com base nos dados fornecidos e retorna um DTO com mensagem e código
        SingleSectorResponseDTO? Save(CreateSectorRequestDTO sectorDto);

        // Atualiza um setor existente com base no ID e nos dados fornecidos, retornando um DTO com mensagem e código
        SingleSectorResponseDTO? Update(int id, UpdateSectorRequestDTO sectorDto);

        // Deleta um setor com base no ID e retorna um DTO com mensagem e código, ou nulo se não encontrado
        SingleSectorResponseDTO? Delete(int id);
    }
}
