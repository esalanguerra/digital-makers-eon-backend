using Eon.DTOs.SectorDTO;
using Eon.Data.Models.Sectors;

namespace Eon.Data.Interfaces.IFactories
{
    public interface ISectorFactoryInterface
    {
        // Valida os dados fornecidos para criar um novo setor.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateCreateSectorRequest(CreateSectorRequestDTO dto);

        // Valida os dados fornecidos para atualizar um setor existente.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateUpdateSectorRequest(UpdateSectorRequestDTO dto);

        // Cria e retorna um objeto Sector com base nos dados fornecidos no CreateSectorRequestDTO.
        Sector CreateSector(CreateSectorRequestDTO dto);

        // Atualiza um objeto Sector existente com base nos dados fornecidos no UpdateSectorRequestDTO.
        // Retorna o objeto Sector atualizado.
        Sector UpdateSector(Sector existingSector, UpdateSectorRequestDTO dto);
    }
}
