using Eon.Com.Application.Configurations.Database.Postgresql;
using Eon.Com.Domain.Models.Entity.TagEntity;
using Eon.Com.Interfaces.Repositories.TagRepository;

namespace Eon.Data.Repositories.TagRepository
{
    /// <summary>
    /// Implementação do repositório para gerenciamento de etiquetas.
    /// </summary>
    public class TagRepository : ITagRepositoryInterface, IDisposable
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        public TagRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Garante que o contexto não seja nulo
        }

        /// <summary>
        /// Adiciona uma nova etiqueta ao banco de dados.
        /// </summary>
        /// <param name="tag">A etiqueta a ser adicionada.</param>
        /// <returns>A etiqueta adicionada.</returns>
        public Tag Add(Tag tag)
        {
            if (tag == null) throw new ArgumentNullException(nameof(tag)); // Garante que a etiqueta não seja nula

            _context.Tags.Add(tag); // Adiciona a etiqueta ao DbSet
            _context.SaveChanges(); // Salva as alterações no banco de dados
            return tag; // Retorna a etiqueta salva
        }

        /// <summary>
        /// Atualiza uma etiqueta existente no banco de dados.
        /// </summary>
        /// <param name="tag">A etiqueta com as atualizações.</param>
        /// <returns>A etiqueta atualizada.</returns>
        public Tag Update(Tag tag)
        {
            if (tag == null) throw new ArgumentNullException(nameof(tag)); // Garante que a etiqueta não seja nula

            var existingTag = _context.Tags.Find(tag.Id);

            if (existingTag != null)
            {
                // Atualiza as propriedades da etiqueta existente
                existingTag.Name = tag.Name;
                existingTag.Description = tag.Description;
                existingTag.SectorId = tag.SectorId;

                _context.SaveChanges(); // Salva as alterações no banco de dados
                return existingTag; // Retorna a etiqueta atualizada
            }

            throw new ArgumentException("Tag not found."); // Lança uma exceção se a etiqueta não for encontrada
        }

        /// <summary>
        /// Deleta uma etiqueta do banco de dados pelo ID.
        /// </summary>
        /// <param name="id">O ID da etiqueta a ser deletada.</param>
        /// <returns>A etiqueta deletada.</returns>
        public Tag Delete(int id)
        {
            var tag = _context.Tags.Find(id);

            if (tag != null)
            {
                _context.Tags.Remove(tag); // Remove a etiqueta do DbSet
                _context.SaveChanges(); // Salva as alterações no banco de dados
                return tag; // Retorna a etiqueta deletada
            }

            throw new ArgumentException("Tag not found."); // Lança uma exceção se a etiqueta não for encontrada
        }

        /// <summary>
        /// Obtém uma etiqueta pelo nome.
        /// </summary>
        /// <param name="name">O nome da etiqueta.</param>
        /// <returns>A etiqueta com o nome especificado ou null se não encontrada.</returns>
        public Tag? GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be null or whitespace.", nameof(name)); // Garante que o nome não seja nulo ou em branco
            return _context.Tags.FirstOrDefault(t => t.Name == name);
        }

        /// <summary>
        /// Obtém uma etiqueta pelo ID.
        /// </summary>
        /// <param name="id">O ID da etiqueta.</param>
        /// <returns>A etiqueta com o ID especificado ou null se não encontrada.</returns>
        public Tag? GetById(int id)
        {
            return _context.Tags.Find(id);
        }

        /// <summary>
        /// Obtém todas as etiquetas.
        /// </summary>
        /// <returns>Uma coleção de todas as etiquetas.</returns>
        public IEnumerable<Tag> GetAll()
        {
            return _context.Tags.ToList();
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
