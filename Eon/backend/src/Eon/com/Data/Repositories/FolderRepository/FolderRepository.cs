using Eon.Com.Application.Configurations.Database.Postgresql;
using Eon.Com.Domain.Models.Entity.FolderEntity;
using Eon.Com.Interfaces.Repositories.FolderRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eon.Data.Repositories.FolderRepository
{
    /// <summary>
    /// Implementação do repositório para gerenciamento de pastas.
    /// </summary>
    public class FolderRepository : IFolderRepositoryInterface, IDisposable
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        public FolderRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Garante que o contexto não seja nulo
        }

        /// <summary>
        /// Adiciona uma nova pasta ao banco de dados.
        /// </summary>
        /// <param name="folder">A pasta a ser adicionada.</param>
        /// <returns>A pasta adicionada.</returns>
        public Folder Add(Folder folder)
        {
            if (folder == null) throw new ArgumentNullException(nameof(folder)); // Garante que a pasta não seja nula

            _context.Folders.Add(folder); // Adiciona a pasta ao DbSet
            _context.SaveChanges(); // Salva as alterações no banco de dados
            return folder; // Retorna a pasta salva
        }

        /// <summary>
        /// Atualiza uma pasta existente no banco de dados.
        /// </summary>
        /// <param name="folder">A pasta com as atualizações.</param>
        /// <returns>A pasta atualizada.</returns>
        public Folder Update(Folder folder)
        {
            if (folder == null) throw new ArgumentNullException(nameof(folder)); // Garante que a pasta não seja nula

            var existingFolder = _context.Folders.Find(folder.Id);

            if (existingFolder != null)
            {
                // Atualiza as propriedades da pasta existente
                existingFolder.Name = folder.Name;
                existingFolder.SectorId = folder.SectorId;

                _context.SaveChanges(); // Salva as alterações no banco de dados
                return existingFolder; // Retorna a pasta atualizada
            }

            throw new ArgumentException("Folder not found."); // Lança uma exceção se a pasta não for encontrada
        }

        /// <summary>
        /// Deleta uma pasta do banco de dados pelo ID.
        /// </summary>
        /// <param name="id">O ID da pasta a ser deletada.</param>
        /// <returns>A pasta deletada.</returns>
        public Folder Delete(int id)
        {
            var folder = _context.Folders.Find(id);

            if (folder != null)
            {
                _context.Folders.Remove(folder); // Remove a pasta do DbSet
                _context.SaveChanges(); // Salva as alterações no banco de dados
                return folder; // Retorna a pasta deletada
            }

            throw new ArgumentException("Folder not found."); // Lança uma exceção se a pasta não for encontrada
        }

        /// <summary>
        /// Obtém uma pasta pelo ID.
        /// </summary>
        /// <param name="id">O ID da pasta.</param>
        /// <returns>A pasta com o ID especificado ou null se não encontrada.</returns>
        public Folder? GetById(int id)
        {
            return _context.Folders.Find(id);
        }

        /// <summary>
        /// Obtém uma pasta pelo nome.
        /// </summary>
        /// <param name="name">O nome da pasta.</param>
        /// <returns>A pasta com o nome especificado ou null se não encontrada.</returns>
        public Folder? GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be null or whitespace.", nameof(name)); // Garante que o nome não seja nulo ou em branco
            return _context.Folders.FirstOrDefault(f => f.Name == name);
        }

        /// <summary>
        /// Obtém todas as pastas.
        /// </summary>
        /// <returns>Uma coleção de todas as pastas.</returns>
        public IEnumerable<Folder> GetAll()
        {
            return _context.Folders.ToList();
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
