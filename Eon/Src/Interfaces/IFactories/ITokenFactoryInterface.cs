using Eon.DTOs.TokenDTO;
using Eon.Data.Models.Users;

namespace Eon.Data.Interfaces.IFactories
{
    public interface ITokenFactoryInterface
    {
        // Valida os dados fornecidos para criar um novo token.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateCreateTokenRequest(CreateTokenRequestDTO dto);

        // Valida os dados fornecidos para atualizar um token existente.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateUpdateTokenRequest(UpdateTokenRequestDTO dto);

        // Cria e retorna um objeto Token com base nos dados fornecidos no CreateTokenRequestDTO.
        Token CreateToken(CreateTokenRequestDTO dto);

        // Atualiza um objeto Token existente com base nos dados fornecidos no UpdateTokenRequestDTO.
        // Retorna o objeto Token atualizado.
        Token UpdateToken(Token existingToken, UpdateTokenRequestDTO dto);
    }
}
