using Eon.Data.Interfaces.IRepositories;
using Eon.Configurations.Database;
using Eon.Data.Models.Messages;

namespace Eon.Data.Repositories
{
    public class MessageSchedulingRepository : IMessageSchedulingRepositoryInterface, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public MessageSchedulingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public MessageScheduling Save(MessageScheduling messageScheduling)
        {
            _context.MessageSchedulings.Add(messageScheduling);
            _context.SaveChanges();
            return messageScheduling;
        }

        public MessageScheduling Update(int id, MessageScheduling messageScheduling)
        {
            var existingMessageScheduling = _context.MessageSchedulings.Find(id);

            if (existingMessageScheduling != null)
            {
                existingMessageScheduling.MessageText = messageScheduling.MessageText;
                existingMessageScheduling.Tag = messageScheduling.Tag;
                existingMessageScheduling.UserId = messageScheduling.UserId;
                existingMessageScheduling.SendDate = messageScheduling.SendDate;
                existingMessageScheduling.Flow = messageScheduling.Flow;
                existingMessageScheduling.WhatsAppNumber = messageScheduling.WhatsAppNumber;
                existingMessageScheduling.Status = messageScheduling.Status;
                _context.SaveChanges();
                return existingMessageScheduling;
            }

            return null;
        }

        public MessageScheduling Delete(int id)
        {
            var messageScheduling = _context.MessageSchedulings.Find(id);

            if (messageScheduling != null)
            {
                _context.MessageSchedulings.Remove(messageScheduling);
                _context.SaveChanges();
                return messageScheduling;
            }

            return null;
        }

        public MessageScheduling? GetById(int id)
        {
            return _context.MessageSchedulings.Find(id);
        }

        public IEnumerable<MessageScheduling> GetByUserId(int userId)
        {
            return _context.MessageSchedulings.Where(messageScheduling => messageScheduling.UserId == userId).ToList();
        }

        public IEnumerable<MessageScheduling> GetBySendDate(DateTime sendDate)
        {
            return _context.MessageSchedulings.Where(messageScheduling => messageScheduling.SendDate == sendDate).ToList();
        }

        public IEnumerable<MessageScheduling> GetAll()
        {
            return _context.MessageSchedulings.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
