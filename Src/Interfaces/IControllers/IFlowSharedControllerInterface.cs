using Eon.DTOs.FlowSharedDTO;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Data.Interfaces.IControllers
{
    public interface IFlowSharedControllerInterface
    {
        // Retorna todos os fluxos compartilhados. Deve retornar um IActionResult que pode incluir um status code e os dados dos fluxos compartilhados.
        IActionResult GetAll();

        // Retorna um fluxo compartilhado específico baseado no ID. Deve retornar um IActionResult com o status e os dados do fluxo compartilhado.
        IActionResult GetById(int id);

        // Cria um novo fluxo compartilhado com base no CreateFlowSharedRequestDTO. Deve retornar um IActionResult com o status da criação.
        IActionResult Save(CreateFlowSharedRequestDTO flowShared);

        // Atualiza um fluxo compartilhado existente com base no ID e no UpdateFlowSharedRequestDTO. Deve retornar um IActionResult com o status da atualização.
        IActionResult Update(int id, UpdateFlowSharedRequestDTO flowShared);

        // Deleta um fluxo compartilhado baseado no ID. Deve retornar um IActionResult com o status da exclusão.
        IActionResult Delete(int id);
    }
}
