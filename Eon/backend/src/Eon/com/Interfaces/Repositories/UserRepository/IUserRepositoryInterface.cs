using Eon.Com.Domain.Models.Entity.UserEntity;

namespace Eon.Com.Interfaces.Repositories.UserRepository
{
    public interface IUserRepositoryInterface
    {
        // Obtém um usuário pelo e-mail. 
        // Retorna um objeto User ou null se não encontrado.
        User? GetByEmail(string email);

        // Obtém um usuário pelo ID.
        // Retorna um objeto User ou null se não encontrado.
        User? GetById(int id);

        // Obtém um usuário pelo nome.
        // Retorna um objeto User ou null se não encontrado.
        User? GetByName(string name);

        // Obtém todos os usuários cadastrados.
        // Retorna uma coleção de objetos User.
        IEnumerable<User> GetAll();

        // Salva um novo usuário no repositório.
        // Retorna o objeto User que foi salvo.
        User Add(User user);

        // Atualiza um usuário existente no repositório.
        // Retorna o objeto User atualizado.
        User Update(User user);

        // Deleta um usuário do repositório pelo ID.
        // Retorna o objeto User que foi deletado.
        User Delete(int id);
    }
}
