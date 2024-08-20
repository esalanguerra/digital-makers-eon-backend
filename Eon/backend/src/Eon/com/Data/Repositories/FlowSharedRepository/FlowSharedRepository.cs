using Eon.Com.Application.Configurations.Database.Postgresql;
using Eon.Com.Domain.Models.Entity.FlowSharedEntity;
using Eon.Com.Interfaces.Repositories.FlowSharedRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eon.Data.Repositories.FlowSharedRepository
{
    /// <summary>
    /// Implementação do repositório para gerenciamento de fluxos compartilhados.
    /// </summary>
    public class FlowSharedRepository : IFlowSharedRepositoryInterface, IDisposable
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        public FlowSharedRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Garante que o contexto não seja nulo
        }

        /// <summary>
        /// Adiciona um novo fluxo compartilhado ao banco de dados.
        /// </summary>
        /// <param name="flowShared">O fluxo compartilhado a ser adicionado.</param>
        /// <returns>O fluxo compartilhado adicionado.</returns>
        public FlowShared Add(FlowShared flowShared)
        {
            if (flowShared == null) throw new ArgumentNullException(nameof(flowShared)); // Garante que o fluxo compartilhado não seja nulo

            _context.FlowsShareds.Add(flowShared); // Adiciona o fluxo compartilhado ao DbSet
            _context.SaveChanges(); // Salva as alterações no banco de dados
            return flowShared; // Retorna o fluxo compartilhado salvo
        }

        /// <summary>
        /// Atualiza um fluxo compartilhado existente no banco de dados.
        /// </summary>
        /// <param name="flowShared">O fluxo compartilhado com as atualizações.</param>
        /// <returns>O fluxo compartilhado atualizado.</returns>
        public FlowShared Update(FlowShared flowShared)
        {
            if (flowShared == null) throw new ArgumentNullException(nameof(flowShared)); // Garante que o fluxo compartilhado não seja nulo

            var existingFlowShared = _context.FlowsShareds.Find(flowShared.Id);

            if (existingFlowShared != null)
            {
                // Atualiza as propriedades do fluxo compartilhado existente
                existingFlowShared.FlowId = flowShared.FlowId;
                existingFlowShared.UserId = flowShared.UserId;
                existingFlowShared.Link = flowShared.Link;
                existingFlowShared.Status = flowShared.Status;

                _context.SaveChanges(); // Salva as alterações no banco de dados
                return existingFlowShared; // Retorna o fluxo compartilhado atualizado
            }

            throw new ArgumentException("FlowShared not found."); // Lança uma exceção se o fluxo compartilhado não for encontrado
        }

        /// <summary>
        /// Deleta um fluxo compartilhado do banco de dados pelo ID.
        /// </summary>
        /// <param name="id">O ID do fluxo compartilhado a ser deletado.</param>
        /// <returns>O fluxo compartilhado deletado.</returns>
        public FlowShared Delete(int id)
        {
            var flowShared = _context.FlowsShareds.Find(id);

            if (flowShared != null)
            {
                _context.FlowsShareds.Remove(flowShared); // Remove o fluxo compartilhado do DbSet
                _context.SaveChanges(); // Salva as alterações no banco de dados
                return flowShared; // Retorna o fluxo compartilhado deletado
            }

            throw new ArgumentException("FlowShared not found."); // Lança uma exceção se o fluxo compartilhado não for encontrado
        }

        /// <summary>
        /// Obtém um fluxo compartilhado pelo ID.
        /// </summary>
        /// <param name="id">O ID do fluxo compartilhado.</param>
        /// <returns>O fluxo compartilhado com o ID especificado ou null se não encontrado.</returns>
        public FlowShared? GetById(int id)
        {
            return _context.FlowsShareds.Find(id);
        }

        /// <summary>
        /// Obtém um fluxo compartilhado pelo link.
        /// </summary>
        /// <param name="link">O link do fluxo compartilhado.</param>
        /// <returns>O fluxo compartilhado com o link especificado ou null se não encontrado.</returns>
        public FlowShared? GetByLink(string link)
        {
            if (string.IsNullOrWhiteSpace(link)) throw new ArgumentException("Link cannot be null or whitespace.", nameof(link)); // Garante que o link não seja nulo ou em branco
            return _context.FlowsShareds.FirstOrDefault(f => f.Link == link);
        }

        /// <summary>
        /// Obtém todos os fluxos compartilhados.
        /// </summary>
        /// <returns>Uma coleção de todos os fluxos compartilhados.</returns>
        public IEnumerable<FlowShared> GetAll()
        {
            return _context.FlowsShareds.ToList();
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
