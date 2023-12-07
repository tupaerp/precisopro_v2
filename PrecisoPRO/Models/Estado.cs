using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PrecisoPRO.Models
{
    [Table("ESTADO")]
    public class Estado
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        [Column("ID")]
        public int Id { get; set; }

        [Column("ESTADO")]
        public string? Descricao { get; set; }

        [Column("UF")]
        public string? Uf { get; set; }

        [Column("BANDEIRA")]
        public string? Bandeira { get; set; }
    }
}
