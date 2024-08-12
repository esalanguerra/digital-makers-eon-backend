using Eon.DTOs.TagDTO;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Data.Interfaces.IControllers
{
    public interface ITagControllerInterface
    {
        // Retorna todas as tags. Deve retornar um IActionResult que pode incluir um status code e os dados das tags.
        IActionResult GetAll();

        // Retorna uma tag específica baseada no ID. Deve retornar um IActionResult com o status e os dados da tag.
        IActionResult GetById(int id);

        // Cria uma nova tag com base no CreateTagRequestDTO. Deve retornar um IActionResult com o status da criação.
        IActionResult Save(CreateTagRequestDTO tag);

        // Atualiza uma tag existente com base no ID e no UpdateTagRequestDTO. Deve retornar um IActionResult com o status da atualização.
        IActionResult Update(int id, UpdateTagRequestDTO tag);

        // Deleta uma tag baseada no ID. Deve retornar um IActionResult com o status da exclusão.
        IActionResult Delete(int id);
    }
}
