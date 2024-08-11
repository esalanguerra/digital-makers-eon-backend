using Eon.DTOs.TokenDTO;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Data.Interfaces.IControllers
{
    public interface ITokenControllerInterface
    {
        // Retorna todos os tokens. Deve retornar um IActionResult que pode incluir um status code e os dados dos tokens.
        IActionResult GetAll();

        // Retorna um token específico baseado no ID. Deve retornar um IActionResult com o status e os dados do token.
        IActionResult GetById(int id);

        // Cria um novo token com base no CreateTokenRequestDTO. Deve retornar um IActionResult com o status da criação.
        IActionResult Save(CreateTokenRequestDTO token);

        // Atualiza um token existente com base no ID e no UpdateTokenRequestDTO. Deve retornar um IActionResult com o status da atualização.
        IActionResult Update(int id, UpdateTokenRequestDTO token);

        // Deleta um token baseado no ID. Deve retornar um IActionResult com o status da exclusão.
        IActionResult Delete(int id);
    }
}
