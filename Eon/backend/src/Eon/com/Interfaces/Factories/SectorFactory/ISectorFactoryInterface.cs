using Eon.Com.Domain.Models.Dto.SectorDto;
using Eon.Com.Domain.Models.Entity.SectorEntity;

namespace Eon.Com.Interfaces.Factories.SectorFactory
{
    public interface ISectorFactoryInterface
    {
        // Valida os dados fornecidos para a criação de um novo setor.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateCreateSectorRequest(CreateSectorRequestDTO dto);

        // Valida os dados fornecidos para a atualização de um setor existente.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateUpdateSectorRequest(UpdateSectorRequestDTO dto);

        // Cria um novo objeto Sector com base nos dados fornecidos no CreateSectorRequestDTO.
        // Retorna o objeto Sector criado.
        Sector CreateSector(CreateSectorRequestDTO dto);

        // Atualiza um objeto Sector existente com base nos dados fornecidos no UpdateSectorRequestDTO.
        // Retorna o objeto Sector atualizado.
        Sector UpdateSector(Sector existingSector, UpdateSectorRequestDTO dto);
    }
}
