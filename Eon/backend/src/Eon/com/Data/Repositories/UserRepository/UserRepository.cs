using Eon.Com.Application.Configurations.Database.Postgresql;
using Eon.Com.Domain.Models.Entity.UserEntity;
using Eon.Com.Interfaces.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eon.Data.Repositories.UserRepository
{
    /// <summary>
    /// Implementação do repositório para gerenciamento de usuários.
    /// </summary>
    public class UserRepository : IUserRepositoryInterface, IDisposable
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        public UserRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Garante que o contexto não seja nulo
        }

        /// <summary>
        /// Adiciona um novo usuário ao banco de dados.
        /// </summary>
        /// <param name="user">O usuário a ser adicionado.</param>
        /// <returns>O usuário adicionado.</returns>
        public User Add(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user)); // Garante que o usuário não seja nulo

            _context.Users.Add(user); // Adiciona o usuário ao DbSet
            _context.SaveChanges(); // Salva as alterações no banco de dados
            return user; // Retorna o usuário salvo
        }

        /// <summary>
        /// Atualiza um usuário existente no banco de dados.
        /// </summary>
        /// <param name="user">O usuário com as atualizações.</param>
        /// <returns>O usuário atualizado.</returns>
        public User Update(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user)); // Garante que o usuário não seja nulo

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

            throw new ArgumentException("User not found."); // Lança uma exceção se o usuário não for encontrado
        }

        /// <summary>
        /// Deleta um usuário do banco de dados pelo ID.
        /// </summary>
        /// <param name="id">O ID do usuário a ser deletado.</param>
        /// <returns>O usuário deletado.</returns>
        public User Delete(int id)
        {
            var user = _context.Users.Find(id);

            if (user != null)
            {
                _context.Users.Remove(user); // Remove o usuário do DbSet
                _context.SaveChanges(); // Salva as alterações no banco de dados
                return user; // Retorna o usuário deletado
            }

            throw new ArgumentException("User not found."); // Lança uma exceção se o usuário não for encontrado
        }

        /// <summary>
        /// Obtém um usuário pelo e-mail.
        /// </summary>
        /// <param name="email">O e-mail do usuário.</param>
        /// <returns>O usuário com o e-mail especificado ou null se não encontrado.</returns>
        public User? GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email cannot be null or whitespace.", nameof(email)); // Garante que o e-mail não seja nulo ou em branco
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        /// <summary>
        /// Obtém um usuário pelo ID.
        /// </summary>
        /// <param name="id">O ID do usuário.</param>
        /// <returns>O usuário com o ID especificado ou null se não encontrado.</returns>
        public User? GetById(int id)
        {
            return _context.Users.Find(id);
        }

        /// <summary>
        /// Obtém um usuário pelo nome.
        /// </summary>
        /// <param name="name">O nome do usuário.</param>
        /// <returns>O usuário com o nome especificado ou null se não encontrado.</returns>
        public User? GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be null or whitespace.", nameof(name)); // Garante que o nome não seja nulo ou em branco
            return _context.Users.FirstOrDefault(u => u.Name == name);
        }

        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        /// <returns>Uma coleção de todos os usuários.</returns>
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        /// <summary>
        /// Libera os recursos do contexto do banco de dados.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose(); // Libera os recursos do contexto do banco de dados
        }
    }
}
