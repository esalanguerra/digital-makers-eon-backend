using Eon.Data.Interfaces.IRepositories;
using Eon.Configurations.Database;
using Eon.Data.Models.Folders;

namespace Eon.Data.Repositories
{
    public class FolderRepository : IFolderRepositoryInterface, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public FolderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Folder Save(Folder folder)
        {
            _context.Folders.Add(folder);
            _context.SaveChanges();
            return folder;
        }

        public Folder Update(int id, Folder folder)
        {
            var existingFolder = _context.Folders.Find(id);

            if (existingFolder != null)
            {
                existingFolder.Name = folder.Name;
                _context.SaveChanges();
                return existingFolder;
            }

            return null;
        }

        public Folder Delete(int id)
        {
            var folder = _context.Folders.Find(id);

            if (folder != null)
            {
                _context.Folders.Remove(folder);
                _context.SaveChanges();
                return folder;
            }

            return null;
        }

        public Folder? GetById(int id)
        {
            return _context.Folders.Find(id);
        }

        public IEnumerable<Folder> GetAll()
        {
            return _context.Folders.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
