using Microsoft.AspNetCore.Mvc;
using Eon.Com.Domain.Models.Dto.FolderDto;

namespace Eon.Com.Interfaces.Controllers.FolderController
{
    public interface IFolderControllerInterface
    {
        /// <summary>
        /// Retorna todas as pastas. Deve retornar um IActionResult que pode incluir um status code e os dados das pastas.
        /// </summary>
        IActionResult GetAll();

        /// <summary>
        /// Retorna uma pasta específica baseada no ID. Deve retornar um IActionResult com o status e os dados da pasta.
        /// </summary>
        IActionResult GetById(int id);

        /// <summary>
        /// Cria uma nova pasta com base no CreateFolderRequestDTO. Deve retornar um IActionResult com o status da criação.
        /// </summary>
        IActionResult Save(CreateFolderRequestDTO folder);

        /// <summary>
        /// Atualiza uma pasta existente com base no ID e no UpdateFolderRequestDTO. Deve retornar um IActionResult com o status da atualização.
        /// </summary>
        IActionResult Update(int id, UpdateFolderRequestDTO folder);

        /// <summary>
        /// Deleta uma pasta baseada no ID. Deve retornar um IActionResult com o status da exclusão.
        /// </summary>
        IActionResult Delete(int id);
    }
}
