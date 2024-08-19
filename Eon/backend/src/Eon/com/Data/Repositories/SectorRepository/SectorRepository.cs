using Eon.Com.Application.Configurations.Database.Postgresql;
using Eon.Com.Domain.Models.Entity.SectorEntity;
using Eon.Com.Interfaces.Repositories.SectorRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eon.Data.Repositories.SectorRepository
{
    /// <summary>
    /// Implementação do repositório para gerenciamento de setores.
    /// </summary>
    public class SectorRepository : ISectorRepositoryInterface, IDisposable
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        public SectorRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Garante que o contexto não seja nulo
        }

        /// <summary>
        /// Adiciona um novo setor ao banco de dados.
        /// </summary>
        /// <param name="sector">O setor a ser adicionado.</param>
        /// <returns>O setor adicionado.</returns>
        public Sector Add(Sector sector)
        {
            if (sector == null) throw new ArgumentNullException(nameof(sector)); // Garante que o setor não seja nulo

            _context.Sectors.Add(sector); // Adiciona o setor ao DbSet
            _context.SaveChanges(); // Salva as alterações no banco de dados
            return sector; // Retorna o setor salvo
        }

        /// <summary>
        /// Atualiza um setor existente no banco de dados.
        /// </summary>
        /// <param name="sector">O setor com as atualizações.</param>
        /// <returns>O setor atualizado.</returns>
        public Sector Update(Sector sector)
        {
            if (sector == null) throw new ArgumentNullException(nameof(sector)); // Garante que o setor não seja nulo

            var existingSector = _context.Sectors.Find(sector.Id);

            if (existingSector != null)
            {
                // Atualiza as propriedades do setor existente
                existingSector.Name = sector.Name;
                existingSector.Description = sector.Description;
                existingSector.UserBusinessId = sector.UserBusinessId;

                _context.SaveChanges(); // Salva as alterações no banco de dados
                return existingSector; // Retorna o setor atualizado
            }

            throw new ArgumentException("Sector not found."); // Lança uma exceção se o setor não for encontrado
        }

        /// <summary>
        /// Deleta um setor do banco de dados pelo ID.
        /// </summary>
        /// <param name="id">O ID do setor a ser deletado.</param>
        /// <returns>O setor deletado.</returns>
        public Sector Delete(int id)
        {
            var sector = _context.Sectors.Find(id);

            if (sector != null)
            {
                _context.Sectors.Remove(sector); // Remove o setor do DbSet
                _context.SaveChanges(); // Salva as alterações no banco de dados
                return sector; // Retorna o setor deletado
            }

            throw new ArgumentException("Sector not found."); // Lança uma exceção se o setor não for encontrado
        }

        /// <summary>
        /// Obtém um setor pelo nome.
        /// </summary>
        /// <param name="name">O nome do setor.</param>
        /// <returns>O setor com o nome especificado ou null se não encontrado.</returns>
        public Sector? GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be null or whitespace.", nameof(name)); // Garante que o nome não seja nulo ou em branco
            return _context.Sectors.FirstOrDefault(s => s.Name == name);
        }

        /// <summary>
        /// Obtém um setor pelo ID.
        /// </summary>
        /// <param name="id">O ID do setor.</param>
        /// <returns>O setor com o ID especificado ou null se não encontrado.</returns>
        public Sector? GetById(int id)
        {
            return _context.Sectors.Find(id);
        }

        /// <summary>
        /// Obtém todos os setores.
        /// </summary>
        /// <returns>Uma coleção de todos os setores.</returns>
        public IEnumerable<Sector> GetAll()
        {
            return _context.Sectors.ToList();
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
