using Eon.DTOs.TokenDTO;
using Eon.Data.Interfaces.IFactories;
using Eon.Data.Models.Users;

namespace Eon.Data.Factories
{
    public class TokenFactory : ITokenFactoryInterface
    {
        public void ValidateCreateTokenRequest(CreateTokenRequestDTO dto)
        {
            ValidateCreateToken(dto);
        }

        public void ValidateUpdateTokenRequest(UpdateTokenRequestDTO dto)
        {
            ValidateUpdateToken(dto);
        }

        private void ValidateCreateToken(CreateTokenRequestDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Value))
                throw new ArgumentException("Value is required.");
        }

        private void ValidateUpdateToken(UpdateTokenRequestDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Value))
                throw new ArgumentException("Value is required.");
        }

        public Token CreateToken(CreateTokenRequestDTO dto)
        {
            return new Token
            {
                Value = dto.Value
            };
        }

        public Token UpdateToken(Token existingToken, UpdateTokenRequestDTO dto)
        {
            existingToken.Value = dto.Value;
            return existingToken;
        }
    }
}
