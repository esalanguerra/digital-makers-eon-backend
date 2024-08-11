using Eon.Data.Interfaces.IRepositories;
using Eon.Configurations.Database;
using Eon.Data.Models.Users;

namespace Eon.Data.Repositories
{
    public class TokenRepository : ITokenRepositoryInterface, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public TokenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Token Save(Token token)
        {
            _context.Tokens.Add(token);
            _context.SaveChanges();
            return token;
        }

        public Token Update(int id, Token token)
        {
            var existingToken = _context.Tokens.Find(id);

            if (existingToken != null)
            {
                existingToken.Value = token.Value;
                _context.SaveChanges();
                return existingToken;
            }

            return null;
        }

        public Token Delete(int id)
        {
            var token = _context.Tokens.Find(id);

            if (token != null)
            {
                _context.Tokens.Remove(token);
                _context.SaveChanges();
                return token;
            }

            return null;
        }

        public Token? GetById(int id)
        {
            return _context.Tokens.Find(id);
        }

        public Token? GetByValue(string value)
        {
            return _context.Tokens.FirstOrDefault(token => token.Value == value);
        }

        public IEnumerable<Token> GetAll()
        {
            return _context.Tokens.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
