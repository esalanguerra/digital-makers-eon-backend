using Eon.Data.Interfaces.IFactories;
using Eon.Data.Interfaces.IRepositories;
using Eon.Data.Interfaces.IServices;
using Eon.DTOs.TokenDTO;

namespace Eon.Api.Services.TokenService
{
    public class TokenService : ITokenServiceInterface
    {
        private readonly ITokenRepositoryInterface _tokenRepository;
        private readonly ITokenFactoryInterface _tokenFactory;

        public TokenService(ITokenRepositoryInterface tokenRepository, ITokenFactoryInterface tokenFactory)
        {
            _tokenRepository = tokenRepository;
            _tokenFactory = tokenFactory;
        }

        public TokenListResponseDTO GetAll()
        {
            var tokens = _tokenRepository.GetAll();
            var tokenDtos = tokens.Select(token => new TokenViewModelDTO(token.Id, token.Value));
            return new TokenListResponseDTO("Success", "200", tokenDtos);
        }

        public SingleTokenResponseDTO? GetById(int id)
        {
            var token = _tokenRepository.GetById(id);
            if (token == null)
            {
                return new SingleTokenResponseDTO("Token not found", "404", null);
            }
            var tokenDto = new TokenViewModelDTO(token.Id, token.Value);
            return new SingleTokenResponseDTO("Success", "200", tokenDto);
        }

        public SingleTokenResponseDTO Save(CreateTokenRequestDTO tokenDto)
        {
            _tokenFactory.ValidateCreateTokenRequest(tokenDto);
            var token = _tokenFactory.CreateToken(tokenDto);
            var savedToken = _tokenRepository.Save(token);
            var responseDto = new TokenViewModelDTO(savedToken.Id, savedToken.Value);
            return new SingleTokenResponseDTO("Token created successfully", "201", responseDto);
        }

        public SingleTokenResponseDTO Update(int id, UpdateTokenRequestDTO tokenDto)
        {
            _tokenFactory.ValidateUpdateTokenRequest(tokenDto);
            var existingToken = _tokenRepository.GetById(id);
            if (existingToken == null)
            {
                return new SingleTokenResponseDTO("Token not found", "404", null);
            }
            var updatedToken = _tokenFactory.UpdateToken(existingToken, tokenDto);
            var savedToken = _tokenRepository.Update(id, updatedToken);
            var responseDto = new TokenViewModelDTO(savedToken.Id, savedToken.Value);
            return new SingleTokenResponseDTO("Token updated successfully", "200", responseDto);
        }

        public SingleTokenResponseDTO Delete(int id)
        {
            var deletedToken = _tokenRepository.Delete(id);
            if (deletedToken == null)
            {
                return new SingleTokenResponseDTO("Token not found", "404", null);
            }
            var responseDto = new TokenViewModelDTO(deletedToken.Id, deletedToken.Value);
            return new SingleTokenResponseDTO("Token deleted successfully", "200", responseDto);
        }
    }
}
