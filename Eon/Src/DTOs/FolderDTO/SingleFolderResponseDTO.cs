using Eon.DTOs.FolderDTO;

// DTO para uma única pasta
public class SingleFolderResponseDTO
{
    // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
    public string Message { get; set; }

    // Código de resposta (por exemplo, um código de status ou erro)
    public string Code { get; set; }

    // Dados da pasta encapsulados em FolderViewModelDTO
    public FolderViewModelDTO Data { get; set; }

    // Construtor para inicializar o DTO com valores específicos
    public SingleFolderResponseDTO(string message, string code, FolderViewModelDTO folder)
    {
        Message = message;
        Code = code;
        Data = folder;
    }

    // Construtor padrão
    public SingleFolderResponseDTO()
    {
    }
}
