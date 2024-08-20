using System.Text.Json.Serialization;

namespace Eon.Com.Domain.Models.Dto.SectorDto
{
    /// <summary>
    /// DTO para a atualização das informações de um setor.
    /// </summary>
    public class UpdateSectorRequestDTO
    {
        /// <summary>
        /// Nome do setor. Este campo é opcional.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Descrição do setor. Este campo é opcional.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Identificador do usuário responsável pelo setor. Este campo é opcional.
        /// </summary>
        public int? UserBusinessId { get; set; }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="name">Nome do setor.</param>
        /// <param name="description">Descrição do setor.</param>
        /// <param name="userBusinessId">Identificador do usuário responsável pelo setor.</param>
        [JsonConstructor]
        public UpdateSectorRequestDTO(
            string? name = null, 
            string? description = null, 
            int? userBusinessId = null)
        {
            Name = name;
            Description = description;
            UserBusinessId = userBusinessId;
        }
    }
}
