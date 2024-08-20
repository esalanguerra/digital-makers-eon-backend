using Eon.Com.Domain.Models.Entity.MessageSchedulingEntity;

namespace Eon.Com.Interfaces.Repositories.MessageSchedulingRepository
{
    public interface IMessageSchedulingRepositoryInterface
    {
        // Obtém uma mensagem agendada pelo e-mail.
        // Retorna um objeto MessageScheduling ou null se não encontrado.
        MessageScheduling? GetByEmail(string email);

        // Obtém uma mensagem agendada pelo ID.
        // Retorna um objeto MessageScheduling ou null se não encontrado.
        MessageScheduling? GetById(int id);

        // Obtém uma mensagem agendada pelo nome.
        // Retorna um objeto MessageScheduling ou null se não encontrado.
        MessageScheduling? GetByName(string name);

        // Obtém todas as mensagens agendadas cadastradas.
        // Retorna uma coleção de objetos MessageScheduling.
        IEnumerable<MessageScheduling> GetAll();

        // Salva uma nova mensagem agendada no repositório.
        // Retorna o objeto MessageScheduling que foi salvo.
        MessageScheduling Add(MessageScheduling messageScheduling);

        // Atualiza uma mensagem agendada existente no repositório.
        // Retorna o objeto MessageScheduling atualizado.
        MessageScheduling Update(MessageScheduling messageScheduling);

        // Deleta uma mensagem agendada do repositório pelo ID.
        // Retorna o objeto MessageScheduling que foi deletado.
        MessageScheduling Delete(int id);
    }
}
