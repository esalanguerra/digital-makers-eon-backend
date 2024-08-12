using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eon.Data.Models.Flows
{
    // Mapeia a classe Flow para a tabela "fluxos" no banco de dados
    [Table("fluxos")]
    public class Flow
    {
        // Define o campo "id" como chave primária da tabela
        [Key]
        [Column("id")]
        public int Id { get; set; }

        // Define o campo "nome_fluxo" como obrigatório
        [Column("nome_fluxo")]
        [Required]
        public string Name { get; set; }

        // Define o campo "pasta_fluxo" como obrigatório
        [Column("pasta_fluxo")]
        [Required]
        public string Folder { get; set; }

        // Construtor padrão
        public Flow()
        {
            Name = string.Empty;
            Folder = string.Empty;
        }

        // Construtor que inicializa a classe com valores específicos
        public Flow(string name, string folder)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Garante que o nome não seja nulo
            Folder = folder ?? throw new ArgumentNullException(nameof(folder)); // Garante que a pasta não seja nula
        }
    }
}
