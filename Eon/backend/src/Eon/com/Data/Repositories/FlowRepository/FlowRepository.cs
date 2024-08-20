using Eon.Com.Application.Configurations.Database.Postgresql;
using Eon.Com.Domain.Models.Entity.FlowEntity;
using Eon.Com.Interfaces.Repositories.FlowRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eon.Data.Repositories.FlowRepository
{
    /// <summary>
    /// Implementação do repositório para gerenciamento de fluxos.
    /// </summary>
    public class FlowRepository : IFlowRepositoryInterface, IDisposable
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        public FlowRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Garante que o contexto não seja nulo
        }

        /// <summary>
        /// Adiciona um novo fluxo ao banco de dados.
        /// </summary>
        /// <param name="flow">O fluxo a ser adicionado.</param>
        /// <returns>O fluxo adicionado.</returns>
        public Flow Add(Flow flow)
        {
            if (flow == null) throw new ArgumentNullException(nameof(flow)); // Garante que o fluxo não seja nulo

            _context.Flows.Add(flow); // Adiciona o fluxo ao DbSet
            _context.SaveChanges(); // Salva as alterações no banco de dados
            return flow; // Retorna o fluxo salvo
        }

        /// <summary>
        /// Atualiza um fluxo existente no banco de dados.
        /// </summary>
        /// <param name="flow">O fluxo com as atualizações.</param>
        /// <returns>O fluxo atualizado.</returns>
        public Flow Update(Flow flow)
        {
            if (flow == null) throw new ArgumentNullException(nameof(flow)); // Garante que o fluxo não seja nulo

            var existingFlow = _context.Flows.Find(flow.Id);

            if (existingFlow != null)
            {
                // Atualiza as propriedades do fluxo existente
                existingFlow.Name = flow.Name;
                existingFlow.FolderId = flow.FolderId;

                _context.SaveChanges(); // Salva as alterações no banco de dados
                return existingFlow; // Retorna o fluxo atualizado
            }

            throw new ArgumentException("Flow not found."); // Lança uma exceção se o fluxo não for encontrado
        }

        /// <summary>
        /// Deleta um fluxo do banco de dados pelo ID.
        /// </summary>
        /// <param name="id">O ID do fluxo a ser deletado.</param>
        /// <returns>O fluxo deletado.</returns>
        public Flow Delete(int id)
        {
            var flow = _context.Flows.Find(id);

            if (flow != null)
            {
                _context.Flows.Remove(flow); // Remove o fluxo do DbSet
                _context.SaveChanges(); // Salva as alterações no banco de dados
                return flow; // Retorna o fluxo deletado
            }

            throw new ArgumentException("Flow not found."); // Lança uma exceção se o fluxo não for encontrado
        }

        /// <summary>
        /// Obtém um fluxo pelo ID.
        /// </summary>
        /// <param name="id">O ID do fluxo.</param>
        /// <returns>O fluxo com o ID especificado ou null se não encontrado.</returns>
        public Flow? GetById(int id)
        {
            return _context.Flows.Find(id);
        }

        /// <summary>
        /// Obtém um fluxo pelo nome.
        /// </summary>
        /// <param name="name">O nome do fluxo.</param>
        /// <returns>O fluxo com o nome especificado ou null se não encontrado.</returns>
        public Flow? GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be null or whitespace.", nameof(name)); // Garante que o nome não seja nulo ou em branco
            return _context.Flows.FirstOrDefault(f => f.Name == name);
        }

        /// <summary>
        /// Obtém todos os fluxos.
        /// </summary>
        /// <returns>Uma coleção de todos os fluxos.</returns>
        public IEnumerable<Flow> GetAll()
        {
            return _context.Flows.ToList();
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
