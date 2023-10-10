using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Final_Bloco02.Model
{
    public class Categoria
    {
        [Key] // Primary Key (Id)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // IDENTITY (1,1)
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Tipo { get; set; } = string.Empty;

        [InverseProperty("Categorias")]
        public virtual ICollection<Produto>? Produtos { get; set; }
    }
}
