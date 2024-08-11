using Eon.DTOs.FlowSharedDTO;

namespace Eon.Data.Interfaces.IServices
{
    public interface IFlowSharedServiceInterface
    {
        // Retorna uma coleção de fluxos compartilhados encapsulada em um DTO com mensagem e código
        FlowSharedListResponseDTO GetAll();

        // Retorna um fluxo compartilhado único com base no ID encapsulado em um DTO com mensagem e código, ou nulo se não encontrado
        SingleFlowSharedResponseDTO? GetById(int id);

        // Cria um novo fluxo compartilhado com base nos dados fornecidos e retorna um DTO com mensagem e código
        SingleFlowSharedResponseDTO? Save(CreateFlowSharedRequestDTO flowSharedDto);

        // Atualiza um fluxo compartilhado existente com base no ID e nos dados fornecidos, retornando um DTO com mensagem e código
        SingleFlowSharedResponseDTO? Update(int id, UpdateFlowSharedRequestDTO flowSharedDto);

        // Deleta um fluxo compartilhado com base no ID e retorna um DTO com mensagem e código, ou nulo se não encontrado
        SingleFlowSharedResponseDTO? Delete(int id);
    }
}
