using Eon.Data.Interfaces.IRepositories;
using Eon.Configurations.Database;
using Eon.Data.Models.Flows;

namespace Eon.Data.Repositories
{
    public class FlowRepository : IFlowRepositoryInterface, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public FlowRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Flow Save(Flow flow)
        {
            _context.Flows.Add(flow);
            _context.SaveChanges();
            return flow;
        }

        public Flow Update(int id, Flow flow)
        {
            var existingFlow = _context.Flows.Find(id);

            if (existingFlow != null)
            {
                existingFlow.Name = flow.Name;
                existingFlow.Folder = flow.Folder;
                _context.SaveChanges();
                return existingFlow;
            }

            return null;
        }

        public Flow Delete(int id)
        {
            var flow = _context.Flows.Find(id);

            if (flow != null)
            {
                _context.Flows.Remove(flow);
                _context.SaveChanges();
                return flow;
            }

            return null;
        }

        public Flow? GetById(int id)
        {
            return _context.Flows.Find(id);
        }

        public Flow? GetByName(string name)
        {
            return _context.Flows.FirstOrDefault(flow => flow.Name == name);
        }

        public IEnumerable<Flow> GetAll()
        {
            return _context.Flows.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
