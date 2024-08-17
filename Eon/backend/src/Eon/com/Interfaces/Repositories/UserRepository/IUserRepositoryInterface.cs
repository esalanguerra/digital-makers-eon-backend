using Eon.Com.Domain.Models.Entity.UserEntity;

namespace Eon.Com.Interfaces.Repositories.UserRepository
{
    public interface IUserRepositoryInterface
    {
        // Obtém um usuário pelo e-mail. Retorna um usuário ou null se não encontrado.
        User? GetByEmail(string email);

        // Obtém um usuário pelo ID. Retorna um usuário ou null se não encontrado.
        User? GetById(int id);

        // Obtém um usuário pelo nome. Retorna um usuário ou null se não encontrado.
        User? GetByName(string name);

        // Obtém todos os usuários. Retorna uma coleção de usuários.
        IEnumerable<User> GetAll();

        // Salva um novo usuário no repositório. Retorna o usuário salvo.
        User Add(User user);

        // Atualiza um usuário existente pelo ID. Retorna o usuário atualizado.
        User Update(User user);

        // Deleta um usuário pelo ID. Retorna o usuário deletado.
        User Delete(int id);
    }
}
