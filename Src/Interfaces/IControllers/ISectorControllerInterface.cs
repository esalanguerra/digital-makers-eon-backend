using Eon.DTOs.SectorDTO;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Data.Interfaces.IControllers
{
    public interface ISectorControllerInterface
    {
        // Retorna todos os setores. Deve retornar um IActionResult que pode incluir um status code e os dados dos setores.
        IActionResult GetAll();

        // Retorna um setor específico baseado no ID. Deve retornar um IActionResult com o status e os dados do setor.
        IActionResult GetById(int id);

        // Cria um novo setor com base no CreateSectorRequestDTO. Deve retornar um IActionResult com o status da criação.
        IActionResult Save(CreateSectorRequestDTO sector);

        // Atualiza um setor existente com base no ID e no UpdateSectorRequestDTO. Deve retornar um IActionResult com o status da atualização.
        IActionResult Update(int id, UpdateSectorRequestDTO sector);

        // Deleta um setor baseado no ID. Deve retornar um IActionResult com o status da exclusão.
        IActionResult Delete(int id);
    }
}
