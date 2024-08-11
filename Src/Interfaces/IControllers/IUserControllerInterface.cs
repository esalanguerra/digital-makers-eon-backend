using Eon.DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Data.Interfaces.IControllers
{
    public interface IUserControllerInterface
    {
        // Retorna todos os usuários. Deve retornar um IActionResult que pode incluir um status code e os dados dos usuários.
        IActionResult GetAll();

        // Retorna um usuário específico baseado no ID. Deve retornar um IActionResult com o status e os dados do usuário.
        IActionResult GetById(int id);

        // Cria um novo usuário com base no CreateUserRequestDTO. Deve retornar um IActionResult com o status da criação.
        IActionResult Save(CreateUserRequestDTO user);

        // Atualiza um usuário existente com base no ID e no UpdateUserRequestDTO. Deve retornar um IActionResult com o status da atualização.
        IActionResult Update(int id, UpdateUserRequestDTO user);

        // Deleta um usuário baseado no ID. Deve retornar um IActionResult com o status da exclusão.
        IActionResult Delete(int id);
    }
}
