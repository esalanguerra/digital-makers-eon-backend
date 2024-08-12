using Eon.DTOs.MessageSchedulingDTO;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Data.Interfaces.IControllers
{
    public interface IMessageSchedulingControllerInterface
    {
        // Retorna todas as mensagens agendadas. Deve retornar um IActionResult que pode incluir um status code e os dados das mensagens agendadas.
        IActionResult GetAll();

        // Retorna uma mensagem agendada específica baseada no ID. Deve retornar um IActionResult com o status e os dados da mensagem agendada.
        IActionResult GetById(int id);

        // Cria uma nova mensagem agendada com base no CreateMessageSchedulingRequestDTO. Deve retornar um IActionResult com o status da criação.
        IActionResult Save(CreateMessageSchedulingRequestDTO messageScheduling);

        // Atualiza uma mensagem agendada existente com base no ID e no UpdateMessageSchedulingRequestDTO. Deve retornar um IActionResult com o status da atualização.
        IActionResult Update(int id, UpdateMessageSchedulingRequestDTO messageScheduling);

        // Deleta uma mensagem agendada baseada no ID. Deve retornar um IActionResult com o status da exclusão.
        IActionResult Delete(int id);
    }
}
