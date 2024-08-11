using Eon.Data.Interfaces.IRepositories;
using Eon.Configurations.Database;
using Eon.Data.Models.Flows;

namespace Eon.Data.Repositories
{
    public class FlowSharedRepository : IFlowSharedRepositoryInterface, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public FlowSharedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public FlowShared Save(FlowShared flowShared)
        {
            _context.FlowsShared.Add(flowShared);
            _context.SaveChanges();
            return flowShared;
        }

        public FlowShared Update(int id, FlowShared flowShared)
        {
            var existingFlowShared = _context.FlowsShared.Find(id);

            if (existingFlowShared != null)
            {
                existingFlowShared.FlowId = flowShared.FlowId;
                existingFlowShared.UserId = flowShared.UserId;
                existingFlowShared.Link = flowShared.Link;
                existingFlowShared.Status = flowShared.Status;
                _context.SaveChanges();
                return existingFlowShared;
            }

            return null;
        }

        public FlowShared Delete(int id)
        {
            var flowShared = _context.FlowsShared.Find(id);

            if (flowShared != null)
            {
                _context.FlowsShared.Remove(flowShared);
                _context.SaveChanges();
                return flowShared;
            }

            return null;
        }

        public FlowShared? GetById(int id)
        {
            return _context.FlowsShared.Find(id);
        }

        public IEnumerable<FlowShared> GetByUserId(int userId)
        {
            return _context.FlowsShared.Where(flowShared => flowShared.UserId == userId).ToList();
        }

        public IEnumerable<FlowShared> GetByFlowId(int flowId)
        {
            return _context.FlowsShared.Where(flowShared => flowShared.FlowId == flowId).ToList();
        }

        public IEnumerable<FlowShared> GetAll()
        {
            return _context.FlowsShared.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
