using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrecisoPRO.Models
{
    [Table("EMITIRCND")]
    public class AssociarEmpUf
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        [Column("ID")]
        public int Id { get; set; }


        [Display(Name = "Id da Empresa")]
        [Required(ErrorMessage = "O campo ID DA EMPRESA é obrigatório.")]
        [Column("ID_EMPRESA")]
        [ForeignKey("Empresa")]
        public required int IdEmpresa { get; set; }

        public Empresa? Empresa { get; set; }

        [Display(Name = "Id do Estado")]
        [Column("ID_ESTADO")]
        [ForeignKey("Estado")]
        public  int IdEstado { get; set; }

        public Estado? Estado { get; set; }

        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        [Column("DATA_CAD")]
        public DateTime? Data_Cad { get; set; }

        [Display(Name = "Cadastro")]
        public string? DataCad
        {
            get { return Data_Cad?.ToShortDateString(); }
        }

        [Display(Name = "Obs")]
        [Column("OBS")]
        public string? Obs { get; set; }


    }
}
