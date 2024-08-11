using Eon.DTOs.TagDTO;
using Eon.Data.Models.Tags;

namespace Eon.Data.Interfaces.IFactories
{
    public interface ITagFactoryInterface
    {
        // Valida os dados fornecidos para criar uma nova etiqueta.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateCreateTagRequest(CreateTagRequestDTO dto);

        // Valida os dados fornecidos para atualizar uma etiqueta existente.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateUpdateTagRequest(UpdateTagRequestDTO dto);

        // Cria e retorna um objeto Tag com base nos dados fornecidos no CreateTagRequestDTO.
        Tag CreateTag(CreateTagRequestDTO dto);

        // Atualiza um objeto Tag existente com base nos dados fornecidos no UpdateTagRequestDTO.
        // Retorna o objeto Tag atualizado.
        Tag UpdateTag(Tag existingTag, UpdateTagRequestDTO dto);
    }
}
