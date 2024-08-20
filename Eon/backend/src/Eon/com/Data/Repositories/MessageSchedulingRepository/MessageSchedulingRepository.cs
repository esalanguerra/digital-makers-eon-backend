using Eon.Com.Application.Configurations.Database.Postgresql;
using Eon.Com.Domain.Models.Entity.MessageSchedulingEntity;
using Eon.Com.Interfaces.Repositories.MessageSchedulingRepository;

namespace Eon.Data.Repositories.MessageSchedulingRepository
{
    /// <summary>
    /// Implementação do repositório para gerenciamento de mensagens agendadas.
    /// </summary>
    public class MessageSchedulingRepository : IMessageSchedulingRepositoryInterface, IDisposable
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o contexto do banco de dados.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        public MessageSchedulingRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); // Garante que o contexto não seja nulo
        }

        /// <summary>
        /// Adiciona uma nova mensagem agendada ao banco de dados.
        /// </summary>
        /// <param name="messageScheduling">A mensagem agendada a ser adicionada.</param>
        /// <returns>A mensagem agendada adicionada.</returns>
        public MessageScheduling Add(MessageScheduling messageScheduling)
        {
            if (messageScheduling == null) throw new ArgumentNullException(nameof(messageScheduling)); // Garante que a mensagem não seja nula

            _context.MessagesSchedulings.Add(messageScheduling); // Adiciona a mensagem ao DbSet
            _context.SaveChanges(); // Salva as alterações no banco de dados
            return messageScheduling; // Retorna a mensagem agendada salva
        }

        /// <summary>
        /// Atualiza uma mensagem agendada existente no banco de dados.
        /// </summary>
        /// <param name="messageScheduling">A mensagem agendada com as atualizações.</param>
        /// <returns>A mensagem agendada atualizada.</returns>
        public MessageScheduling Update(MessageScheduling messageScheduling)
        {
            if (messageScheduling == null) throw new ArgumentNullException(nameof(messageScheduling)); // Garante que a mensagem não seja nula

            var existingMessageScheduling = _context.MessagesSchedulings.Find(messageScheduling.Id);

            if (existingMessageScheduling != null)
            {
                // Atualiza as propriedades da mensagem existente
                existingMessageScheduling.MessageText = messageScheduling.MessageText;
                existingMessageScheduling.TagId = messageScheduling.TagId;
                existingMessageScheduling.UserId = messageScheduling.UserId;
                existingMessageScheduling.FlowId = messageScheduling.FlowId;
                existingMessageScheduling.SendDate = messageScheduling.SendDate;
                existingMessageScheduling.WhatsAppNumber = messageScheduling.WhatsAppNumber;
                existingMessageScheduling.Status = messageScheduling.Status;

                _context.SaveChanges(); // Salva as alterações no banco de dados
                return existingMessageScheduling; // Retorna a mensagem agendada atualizada
            }

            throw new ArgumentException("MessageScheduling not found."); // Lança uma exceção se a mensagem não for encontrada
        }

        /// <summary>
        /// Deleta uma mensagem agendada do banco de dados pelo ID.
        /// </summary>
        /// <param name="id">O ID da mensagem agendada a ser deletada.</param>
        /// <returns>A mensagem agendada deletada.</returns>
        public MessageScheduling Delete(int id)
        {
            var messageScheduling = _context.MessagesSchedulings.Find(id);

            if (messageScheduling != null)
            {
                _context.MessagesSchedulings.Remove(messageScheduling); // Remove a mensagem do DbSet
                _context.SaveChanges(); // Salva as alterações no banco de dados
                return messageScheduling; // Retorna a mensagem agendada deletada
            }

            throw new ArgumentException("MessageScheduling not found."); // Lança uma exceção se a mensagem não for encontrada
        }

        /// <summary>
        /// Obtém uma mensagem agendada pelo e-mail.
        /// </summary>
        /// <param name="email">O e-mail associado à mensagem agendada.</param>
        /// <returns>A mensagem agendada com o e-mail especificado ou null se não encontrada.</returns>
        public MessageScheduling? GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email cannot be null or whitespace.", nameof(email)); // Garante que o e-mail não seja nulo ou em branco
            return _context.MessagesSchedulings.FirstOrDefault(ms => ms.WhatsAppNumber == email);
        }

        /// <summary>
        /// Obtém uma mensagem agendada pelo ID.
        /// </summary>
        /// <param name="id">O ID da mensagem agendada.</param>
        /// <returns>A mensagem agendada com o ID especificado ou null se não encontrada.</returns>
        public MessageScheduling? GetById(int id)
        {
            return _context.MessagesSchedulings.Find(id);
        }

        /// <summary>
        /// Obtém uma mensagem agendada pelo nome.
        /// </summary>
        /// <param name="name">O nome associado à mensagem agendada.</param>
        /// <returns>A mensagem agendada com o nome especificado ou null se não encontrada.</returns>
        public MessageScheduling? GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be null or whitespace.", nameof(name)); // Garante que o nome não seja nulo ou em branco
            return _context.MessagesSchedulings.FirstOrDefault(ms => ms.MessageText == name);
        }

        /// <summary>
        /// Obtém todas as mensagens agendadas.
        /// </summary>
        /// <returns>Uma coleção de todas as mensagens agendadas.</returns>
        public IEnumerable<MessageScheduling> GetAll()
        {
            return _context.MessagesSchedulings.ToList();
        }

        /// <summary>
        /// Libera os recursos do contexto do banco de dados.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose(); // Libera os recursos do contexto do banco de dados
        }
    }
}
