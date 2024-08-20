namespace Eon.Com.Interfaces.Entities.MessageSchedulingEntity
{
    // Interface para definir a estrutura da entidade de mensagem agendada.
    public interface IMessageSchedulingEntityInterface
    {
        // Identificador único da mensagem agendada.
        // Deve ser um valor único para cada mensagem e geralmente é gerado automaticamente.
        int Id { get; set; }

        // Texto da mensagem.
        // Representa o conteúdo textual da mensagem que será enviada.
        string MessageText { get; set; }

        // Identificador da etiqueta associada à mensagem.
        // Referencia a tag que categoriza a mensagem.
        int TagId { get; set; }

        // Identificador do usuário responsável pela mensagem.
        // Referencia o usuário que criou ou é responsável pela mensagem.
        int UserId { get; set; }

        // Identificador do fluxo associado à mensagem.
        // Referencia o fluxo ao qual a mensagem pertence.
        int FlowId { get; set; }

        // Data e hora de envio da mensagem.
        // Define quando a mensagem está programada para ser enviada.
        DateTime SendDate { get; set; }

        // Número de WhatsApp para o qual a mensagem será enviada.
        // Deve conter apenas números e alguns caracteres especiais.
        string WhatsAppNumber { get; set; }

        // Status da mensagem.
        // Representa o estado atual da mensagem, como Agendada, Enviada, ou Cancelada.
        string Status { get; set; }
    }
}
