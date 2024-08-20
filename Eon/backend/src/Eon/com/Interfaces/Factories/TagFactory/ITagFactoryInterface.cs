using Eon.Com.Domain.Models.Dto.TagDto;
using Eon.Com.Domain.Models.Entity.TagEntity;

namespace Eon.Com.Interfaces.Factories.TagFactory
{
    public interface ITagFactoryInterface
    {
        // Valida os dados fornecidos para a criação de uma nova etiqueta.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateCreateTagRequest(CreateTagRequestDTO dto);

        // Valida os dados fornecidos para a atualização de uma etiqueta existente.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateUpdateTagRequest(UpdateTagRequestDTO dto);

        // Cria um novo objeto Tag com base nos dados fornecidos no CreateTagRequestDTO.
        // Retorna o objeto Tag criado.
        Tag CreateTag(CreateTagRequestDTO dto);

        // Atualiza um objeto Tag existente com base nos dados fornecidos no UpdateTagRequestDTO.
        // Retorna o objeto Tag atualizado.
        Tag UpdateTag(Tag existingTag, UpdateTagRequestDTO dto);
    }
}
