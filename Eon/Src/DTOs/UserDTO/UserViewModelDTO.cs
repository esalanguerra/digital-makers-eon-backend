namespace Eon.DTOs.UserDTO
{
    public class UserViewModelDTO
    {
        // Identificador único do usuário
        public int Id { get; set; }

        // Nome do usuário
        public string Name { get; set; }

        // E-mail do usuário
        public string Email { get; set; }

        // Construtor padrão
        public UserViewModelDTO() { }

        // Construtor para inicializar o DTO com valores específicos
        public UserViewModelDTO(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
