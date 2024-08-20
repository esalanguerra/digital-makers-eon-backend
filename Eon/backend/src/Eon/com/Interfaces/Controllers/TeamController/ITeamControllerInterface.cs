using Microsoft.AspNetCore.Mvc;
using Eon.Com.Domain.Models.Dto.TeamDto;

namespace Eon.Com.Interfaces.Controllers.TeamController
{
    public interface ITeamControllerInterface
    {
        // Retorna todos os times. Deve retornar um IActionResult que pode incluir um status code e os dados dos times.
        IActionResult GetAll();

        // Retorna um time específico baseado no ID. Deve retornar um IActionResult com o status e os dados do time.
        IActionResult GetById(int id);

        // Cria um novo time com base no CreateTeamRequestDTO. Deve retornar um IActionResult com o status da criação.
        IActionResult Save(CreateTeamRequestDTO team);

        // Atualiza um time existente com base no ID e no UpdateTeamRequestDTO. Deve retornar um IActionResult com o status da atualização.
        IActionResult Update(int id, UpdateTeamRequestDTO team);

        // Deleta um time baseado no ID. Deve retornar um IActionResult com o status da exclusão.
        IActionResult Delete(int id);
    }
}
