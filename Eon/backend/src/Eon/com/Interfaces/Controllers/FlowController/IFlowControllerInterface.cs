using Microsoft.AspNetCore.Mvc;
using Eon.Com.Domain.Models.Dto.FlowDto;

namespace Eon.Com.Interfaces.Controllers.FlowController
{
    public interface IFlowControllerInterface
    {
        /// <summary>
        /// Retorna todos os fluxos. Deve retornar um IActionResult que pode incluir um status code e os dados dos fluxos.
        /// </summary>
        IActionResult GetAll();

        /// <summary>
        /// Retorna um fluxo específico baseado no ID. Deve retornar um IActionResult com o status e os dados do fluxo.
        /// </summary>
        IActionResult GetById(int id);

        /// <summary>
        /// Cria um novo fluxo com base no CreateFlowRequestDTO. Deve retornar um IActionResult com o status da criação.
        /// </summary>
        IActionResult Save(CreateFlowRequestDTO flow);

        /// <summary>
        /// Atualiza um fluxo existente com base no ID e no UpdateFlowRequestDTO. Deve retornar um IActionResult com o status da atualização.
        /// </summary>
        IActionResult Update(int id, UpdateFlowRequestDTO flow);

        /// <summary>
        /// Deleta um fluxo baseado no ID. Deve retornar um IActionResult com o status da exclusão.
        /// </summary>
        IActionResult Delete(int id);
    }
}
