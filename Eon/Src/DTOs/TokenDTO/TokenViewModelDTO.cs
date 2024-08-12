namespace Eon.DTOs.TokenDTO
{
    public class TokenViewModelDTO
    {
        // Identificador único do token
        public int Id { get; set; }

        // Valor do token
        public string Value { get; set; }

        // Construtor padrão
        public TokenViewModelDTO() { }

        // Construtor para inicializar o DTO com valores específicos
        public TokenViewModelDTO(int id, string value)
        {
            Id = id;
            Value = value;
        }
    }
}
