using Eon.Data.Models.Users;

namespace Eon.Data.Interfaces.IRepositories
{
    public interface ITokenRepositoryInterface
    {
        // Obtém todos os tokens. Retorna uma coleção de tokens.
        IEnumerable<Token> GetAll();

        // Obtém um token pelo ID. Retorna um token ou null se não encontrado.
        Token? GetById(int id);

        // Obtém um token pelo valor. Retorna um token ou null se não encontrado.
        Token? GetByValue(string value);

        // Salva um novo token no repositório. Retorna o token salvo.
        Token Save(Token token);

        // Atualiza um token existente pelo ID. Retorna o token atualizado.
        Token Update(int id, Token token);

        // Deleta um token pelo ID. Retorna o token deletado.
        Token Delete(int id);
    }
}
