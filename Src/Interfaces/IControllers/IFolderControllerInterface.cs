using Eon.DTOs.FolderDTO;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Data.Interfaces.IControllers
{
    public interface IFolderControllerInterface
    {
        // Retorna todas as pastas. Deve retornar um IActionResult que pode incluir um status code e os dados das pastas.
        IActionResult GetAll();

        // Retorna uma pasta específica baseada no ID. Deve retornar um IActionResult com o status e os dados da pasta.
        IActionResult GetById(int id);

        // Cria uma nova pasta com base no CreateFolderRequestDTO. Deve retornar um IActionResult com o status da criação.
        IActionResult Save(CreateFolderRequestDTO folder);

        // Atualiza uma pasta existente com base no ID e no UpdateFolderRequestDTO. Deve retornar um IActionResult com o status da atualização.
        IActionResult Update(int id, UpdateFolderRequestDTO folder);

        // Deleta uma pasta baseada no ID. Deve retornar um IActionResult com o status da exclusão.
        IActionResult Delete(int id);
    }
}
