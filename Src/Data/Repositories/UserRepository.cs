using Eon.Data.Interfaces.IRepositories;
using Eon.Configurations.Database;
using Eon.Data.Models.Users;

namespace Eon.Data.Repositories
{
    public class UserRepository : IUserRepositoryInterface, IDisposable
    {
        private readonly ApplicationDbContext _context;

        // Construtor que recebe o contexto do banco de dados
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para salvar um novo usuário no banco de dados
        public User Save(User user)
        {
            _context.Users.Add(user); // Adiciona o usuário ao DbSet
            _context.SaveChanges(); // Salva as alterações no banco de dados
            return user; // Retorna o usuário salvo
        }

        // Método para atualizar um usuário existente
        public User Update(int id, User user)
        {
            // Encontra o usuário existente pelo ID
            var existingUser = _context.Users.Find(id);

            if (existingUser != null)
            {
                // Atualiza as propriedades do usuário existente
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                // Atualize outras propriedades conforme necessário

                _context.SaveChanges(); // Salva as alterações no banco de dados
                return existingUser; // Retorna o usuário atualizado
            }

            return null; // Retorna nulo se o usuário não for encontrado
        }

        // Método para deletar um usuário pelo ID
        public User Delete(int id)
        {
            // Encontra o usuário pelo ID
            var user = _context.Users.Find(id);

            if (user != null)
            {
                _context.Users.Remove(user); // Remove o usuário do DbSet
                _context.SaveChanges(); // Salva as alterações no banco de dados
                return user; // Retorna o usuário deletado
            }

            return null; // Retorna nulo se o usuário não for encontrado
        }

        // Método para obter um usuário pelo e-mail
        public User? GetByEmail(string email)
        {
            // Retorna o primeiro usuário que corresponde ao e-mail informado
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        // Método para obter um usuário pelo ID
        public User? GetById(int id)
        {
            // Encontra o usuário pelo ID
            return _context.Users.Find(id);
        }

        // Método para obter um usuário pelo nome
        public User? GetByName(string name)
        {
            // Retorna o primeiro usuário que corresponde ao nome informado
            return _context.Users.FirstOrDefault(u => u.Name == name);
        }

        // Método para obter todos os usuários
        public IEnumerable<User> GetAll()
        {
            // Retorna todos os usuários no DbSet como uma lista
            return _context.Users.ToList();
        }

        // Método para liberar recursos do contexto
        public void Dispose()
        {
            _context.Dispose(); // Libera os recursos do contexto do banco de dados
        }
    }
}
