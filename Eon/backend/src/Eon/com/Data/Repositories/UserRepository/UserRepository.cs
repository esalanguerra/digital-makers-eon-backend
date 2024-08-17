using Eon.Com.Application.Configurations.Database.Postgresql;
using Eon.Com.Domain.Models.Entity.UserEntity;
using Eon.Com.Interfaces.Repositories.UserRepository;

namespace Eon.Data.Repositories.UserRepository
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
        public User Add(User user)
        {
            _context.Users.Add(user); // Adiciona o usuário ao DbSet
            _context.SaveChanges(); // Salva as alterações no banco de dados
            return user; // Retorna o usuário salvo
        }

        // Método para atualizar um usuário existente
        public User Update(User user)
        {
            var existingUser = _context.Users.Find(user.Id);

            if (existingUser != null)
            {
                // Atualiza as propriedades do usuário existente
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.AvatarUrl = user.AvatarUrl;
                existingUser.PhoneWhatsapp = user.PhoneWhatsapp;
                existingUser.Address = user.Address;
                existingUser.Notes = user.Notes;

                _context.SaveChanges(); // Salva as alterações no banco de dados
                return existingUser; // Retorna o usuário atualizado
            }

            throw new ArgumentException("User not found.");
        }

        // Método para deletar um usuário pelo ID
        public User Delete(int id)
        {
            var user = _context.Users.Find(id);

            if (user != null)
            {
                _context.Users.Remove(user); // Remove o usuário do DbSet
                _context.SaveChanges(); // Salva as alterações no banco de dados
                return user; // Retorna o usuário deletado
            }

            throw new ArgumentException("User not found.");
        }

        // Método para obter um usuário pelo e-mail
        public User? GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        // Método para obter um usuário pelo ID
        public User? GetById(int id)
        {
            return _context.Users.Find(id);
        }

        // Método para obter um usuário pelo nome
        public User? GetByName(string name)
        {
            return _context.Users.FirstOrDefault(u => u.Name == name);
        }

        // Método para obter todos os usuários
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        // Método para liberar recursos do contexto
        public void Dispose()
        {
            _context.Dispose(); // Libera os recursos do contexto do banco de dados
        }
    }
}
