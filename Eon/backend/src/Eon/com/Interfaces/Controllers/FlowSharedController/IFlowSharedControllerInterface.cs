using Microsoft.AspNetCore.Mvc;
using Eon.Com.Domain.Models.Dto.FlowSharedDto;

namespace Eon.Com.Interfaces.Controllers.FlowSharedController
{
    public interface IFlowSharedControllerInterface
    {
        /// <summary>
        /// Retorna todos os fluxos compartilhados. Deve retornar um IActionResult que pode incluir um status code e os dados dos fluxos compartilhados.
        /// </summary>
        IActionResult GetAll();

        /// <summary>
        /// Retorna um fluxo compartilhado específico baseado no ID. Deve retornar um IActionResult com o status e os dados do fluxo compartilhado.
        /// </summary>
        IActionResult GetById(int id);

        /// <summary>
        /// Cria um novo fluxo compartilhado com base no CreateFlowSharedRequestDTO. Deve retornar um IActionResult com o status da criação.
        /// </summary>
        IActionResult Save(CreateFlowSharedRequestDTO flowShared);

        /// <summary>
        /// Atualiza um fluxo compartilhado existente com base no ID e no UpdateFlowSharedRequestDTO. Deve retornar um IActionResult com o status da atualização.
        /// </summary>
        IActionResult Update(int id, UpdateFlowSharedRequestDTO flowShared);

        /// <summary>
        /// Deleta um fluxo compartilhado baseado no ID. Deve retornar um IActionResult com o status da exclusão.
        /// </summary>
        IActionResult Delete(int id);
    }
}
