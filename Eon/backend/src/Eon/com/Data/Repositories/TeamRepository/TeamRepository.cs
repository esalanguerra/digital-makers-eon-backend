using Eon.Com.Application.Configurations.Database.Postgresql;
using Eon.Com.Domain.Models.Entity.TeamEntity;
using Eon.Com.Interfaces.Repositories.TeamRepository;

namespace Eon.Data.Repositories.TeamRepository
{
    /// <summary>
    /// Implementação do repositório para gerenciamento de equipes.
    /// </summary>
    public class TeamRepository : ITeamRepositoryInterface, IDisposable
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        public TeamRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Garante que o contexto não seja nulo
        }

        /// <summary>
        /// Adiciona uma nova equipe ao banco de dados.
        /// </summary>
        /// <param name="team">A equipe a ser adicionada.</param>
        /// <returns>A equipe adicionada.</returns>
        public Team Add(Team team)
        {
            if (team == null) throw new ArgumentNullException(nameof(team)); // Garante que a equipe não seja nula

            _context.Teams.Add(team); // Adiciona a equipe ao DbSet
            _context.SaveChanges(); // Salva as alterações no banco de dados
            return team; // Retorna a equipe salva
        }

        /// <summary>
        /// Atualiza uma equipe existente no banco de dados.
        /// </summary>
        /// <param name="team">A equipe com as atualizações.</param>
        /// <returns>A equipe atualizada.</returns>
        public Team Update(Team team)
        {
            if (team == null) throw new ArgumentNullException(nameof(team)); // Garante que a equipe não seja nula

            var existingTeam = _context.Teams.Find(team.Id);

            if (existingTeam != null)
            {
                // Atualiza as propriedades da equipe existente
                existingTeam.Name = team.Name;
                existingTeam.Description = team.Description;

                _context.SaveChanges(); // Salva as alterações no banco de dados
                return existingTeam; // Retorna a equipe atualizada
            }

            throw new ArgumentException("Team not found."); // Lança uma exceção se a equipe não for encontrada
        }

        /// <summary>
        /// Deleta uma equipe do banco de dados pelo ID.
        /// </summary>
        /// <param name="id">O ID da equipe a ser deletada.</param>
        /// <returns>A equipe deletada.</returns>
        public Team Delete(int id)
        {
            var team = _context.Teams.Find(id);

            if (team != null)
            {
                _context.Teams.Remove(team); // Remove a equipe do DbSet
                _context.SaveChanges(); // Salva as alterações no banco de dados
                return team; // Retorna a equipe deletada
            }

            throw new ArgumentException("Team not found."); // Lança uma exceção se a equipe não for encontrada
        }

        /// <summary>
        /// Obtém uma equipe pelo nome.
        /// </summary>
        /// <param name="name">O nome da equipe.</param>
        /// <returns>A equipe com o nome especificado ou null se não encontrada.</returns>
        public Team? GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be null or whitespace.", nameof(name)); // Garante que o nome não seja nulo ou em branco
            return _context.Teams.FirstOrDefault(t => t.Name == name);
        }

        /// <summary>
        /// Obtém uma equipe pelo ID.
        /// </summary>
        /// <param name="id">O ID da equipe.</param>
        /// <returns>A equipe com o ID especificado ou null se não encontrada.</returns>
        public Team? GetById(int id)
        {
            return _context.Teams.Find(id);
        }

        /// <summary>
        /// Obtém todas as equipes.
        /// </summary>
        /// <returns>Uma coleção de todas as equipes.</returns>
        public IEnumerable<Team> GetAll()
        {
            return _context.Teams.ToList();
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
