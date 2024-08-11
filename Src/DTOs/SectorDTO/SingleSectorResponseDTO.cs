using Eon.DTOs.SectorDTO;

// DTO para um único setor
public class SingleSectorResponseDTO
{
    // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
    public string Message { get; set; }

    // Código de resposta (por exemplo, um código de status ou erro)
    public string Code { get; set; }

    // Dados do setor encapsulados em SectorViewModelDTO
    public SectorViewModelDTO Data { get; set; }

    // Construtor para inicializar o DTO com valores específicos
    public SingleSectorResponseDTO(string message, string code, SectorViewModelDTO sector)
    {
        Message = message;
        Code = code;
        Data = sector;
    }

    // Construtor padrão
    public SingleSectorResponseDTO()
    {
    }
}

// DTO para uma coleção de setores
public class SectorListResponseDTO
{
    // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
    public string Message { get; set; }

    // Código de resposta (por exemplo, um código de status ou erro)
    public string Code { get; set; }

    // Lista de setores encapsulados em SectorViewModelDTO
    public IEnumerable<SectorViewModelDTO> Data { get; set; }

    // Construtor para inicializar o DTO com valores específicos
    public SectorListResponseDTO(string message, string code, IEnumerable<SectorViewModelDTO> sectors)
    {
        Message = message;
        Code = code;
        Data = sectors;
    }

    // Construtor padrão
    public SectorListResponseDTO()
    {
        Data = new List<SectorViewModelDTO>();
    }
}

