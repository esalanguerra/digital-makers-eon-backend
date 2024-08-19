using System.Text.Json.Serialization;

namespace Eon.Com.Domain.Models.Dto.SectorDto
{
    /// <summary>
    /// DTO para a criação de um novo setor.
    /// </summary>
    public class CreateSectorRequestDTO
    {
        /// <summary>
        /// Nome do setor. Este campo é obrigatório.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição do setor. Este campo é obrigatório.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Identificador do usuário responsável pelo setor. Este campo é obrigatório.
        /// </summary>
        public int UserBusinessId { get; set; }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="name">Nome do setor.</param>
        /// <param name="description">Descrição do setor.</param>
        /// <param name="userBusinessId">Identificador do usuário responsável pelo setor.</param>
        [JsonConstructor]
        public CreateSectorRequestDTO(
            string name, 
            string description, 
            int userBusinessId)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Garante que o nome não seja nulo
            Description = description ?? throw new ArgumentNullException(nameof(description)); // Garante que a descrição não seja nula
            UserBusinessId = userBusinessId; // Inicializa o ID do usuário responsável
        }
    }
}
