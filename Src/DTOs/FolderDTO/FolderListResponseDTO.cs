using Eon.DTOs.FolderDTO;

// DTO para uma coleção de pastas
public class FolderListResponseDTO
{
    // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
    public string Message { get; set; }

    // Código de resposta (por exemplo, um código de status ou erro)
    public string Code { get; set; }

    // Lista de pastas encapsuladas em FolderViewModelDTO
    public IEnumerable<FolderViewModelDTO> Data { get; set; }

    // Construtor para inicializar o DTO com valores específicos
    public FolderListResponseDTO(string message, string code, IEnumerable<FolderViewModelDTO> folders)
    {
        Message = message;
        Code = code;
        Data = folders;
    }

    // Construtor padrão
    public FolderListResponseDTO()
    {
        Data = new List<FolderViewModelDTO>();
    }
}
