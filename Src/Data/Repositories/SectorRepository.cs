using Eon.Data.Interfaces.IRepositories;
using Eon.Configurations.Database;
using Eon.Data.Models.Sectors;

namespace Eon.Data.Repositories
{
    public class SectorRepository : ISectorRepositoryInterface, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public SectorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Sector Save(Sector sector)
        {
            _context.Sectors.Add(sector);
            _context.SaveChanges();
            return sector;
        }

        public Sector Update(int id, Sector sector)
        {
            var existingSector = _context.Sectors.Find(id);

            if (existingSector != null)
            {
                existingSector.Team = sector.Team;
                existingSector.Description = sector.Description;
                existingSector.TeamId = sector.TeamId;
                _context.SaveChanges();
                return existingSector;
            }

            return null;
        }

        public Sector Delete(int id)
        {
            var sector = _context.Sectors.Find(id);

            if (sector != null)
            {
                _context.Sectors.Remove(sector);
                _context.SaveChanges();
                return sector;
            }

            return null;
        }

        public Sector? GetById(int id)
        {
            return _context.Sectors.Find(id);
        }

        public Sector? GetByTeamId(int teamId)
        {
            return _context.Sectors.FirstOrDefault(sector => sector.TeamId == teamId);
        }

        public IEnumerable<Sector> GetAll()
        {
            return _context.Sectors.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
