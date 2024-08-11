using Eon.Data.Models.Users;

namespace Eon.Data.Interfaces.IRepositories
{
    public interface IUserRepositoryInterface
    {
        // Obtém um usuário pelo e-mail. Retorna um usuário ou null se não encontrado.
        User? GetByEmail(string email) => null;

        // Obtém um usuário pelo ID. Retorna um usuário ou null se não encontrado.
        User? GetById(int id) => null;

        // Obtém um usuário pelo nome. Retorna um usuário ou null se não encontrado.
        User? GetByName(string name) => null;

        // Obtém todos os usuários. Retorna uma coleção de usuários.
        IEnumerable<User> GetAll();

        // Salva um novo usuário no repositório. Retorna o usuário salvo.
        User Save(User user);

        // Atualiza um usuário existente pelo ID. Retorna o usuário atualizado.
        User Update(int id, User user);

        // Deleta um usuário pelo ID. Retorna o usuário deletado.
        User Delete(int id);
    }
}
