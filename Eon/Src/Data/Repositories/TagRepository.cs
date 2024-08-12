using Eon.Data.Interfaces.IRepositories;
using Eon.Configurations.Database;
using Eon.Data.Models.Tags;

namespace Eon.Data.Repositories
{
    public class TagRepository : ITagRepositoryInterface, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Tag Save(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return tag;
        }

        public Tag Update(int id, Tag tag)
        {
            var existingTag = _context.Tags.Find(id);

            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.Description = tag.Description;
                _context.SaveChanges();
                return existingTag;
            }

            return null;
        }

        public Tag Delete(int id)
        {
            var tag = _context.Tags.Find(id);

            if (tag != null)
            {
                _context.Tags.Remove(tag);
                _context.SaveChanges();
                return tag;
            }

            return null;
        }

        public Tag? GetById(int id)
        {
            return _context.Tags.Find(id);
        }

        public Tag? GetByName(string name)
        {
            return _context.Tags.FirstOrDefault(tag => tag.Name == name);
        }

        public IEnumerable<Tag> GetAll()
        {
            return _context.Tags.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
