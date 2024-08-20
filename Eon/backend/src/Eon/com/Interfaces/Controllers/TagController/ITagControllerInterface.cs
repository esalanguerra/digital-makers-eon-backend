using Microsoft.AspNetCore.Mvc;
using Eon.Com.Domain.Models.Dto.TagDto;

namespace Eon.Com.Interfaces.Controllers.TagController
{
    public interface ITagControllerInterface
    {
        // Retorna todas as etiquetas. Deve retornar um IActionResult que pode incluir um status code e os dados das etiquetas.
        IActionResult GetAll();

        // Retorna uma etiqueta específica baseada no ID. Deve retornar um IActionResult com o status e os dados da etiqueta.
        IActionResult GetById(int id);

        // Cria uma nova etiqueta com base no CreateTagRequestDTO. Deve retornar um IActionResult com o status da criação.
        IActionResult Save(CreateTagRequestDTO tag);

        // Atualiza uma etiqueta existente com base no ID e no UpdateTagRequestDTO. Deve retornar um IActionResult com o status da atualização.
        IActionResult Update(int id, UpdateTagRequestDTO tag);

        // Deleta uma etiqueta baseada no ID. Deve retornar um IActionResult com o status da exclusão.
        IActionResult Delete(int id);
    }
}
