// DTO para uma coleção de etiquetas
using Eon.DTOs.TagDTO;

public class TagListResponseDTO
{
    // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
    public string Message { get; set; }

    // Código de resposta (por exemplo, um código de status ou erro)
    public string Code { get; set; }

    // Lista de etiquetas encapsuladas em TagViewModelDTO
    public IEnumerable<TagViewModelDTO> Data { get; set; }

    // Construtor para inicializar o DTO com valores específicos
    public TagListResponseDTO(string message, string code, IEnumerable<TagViewModelDTO> tags)
    {
        Message = message;
        Code = code;
        Data = tags;
    }

    // Construtor padrão
    public TagListResponseDTO()
    {
        Data = new List<TagViewModelDTO>();
    }
}
