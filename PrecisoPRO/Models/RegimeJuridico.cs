using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrecisoPRO.Models
{
    [Table("REGIMEJUR")]
    public class RegimeJuridico
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        [Column("ID")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Column("NOME")]
        public string? Nome { get; set; }


        [Display(Name = "Descrição")]
        [Column("DESCRICAO")]
        public string? Descricao { get; set; }

        // ***************** DADOS INTERNOS DE CONTROLE ****************************************
        [Display(Name = "Status")]
        [Column("STATUS")]
        public sbyte? Status { get; set; }


        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        [Column("DATA_CAD")]
        public DateTime? Data_Cad { get; set; }

        [Display(Name = "Cadastro")]
        public string? DataCad
        {
            get { return Data_Cad?.ToShortDateString(); }
        }

        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        [Column("DATA_ALT")]
        public DateTime? Data_Alt { get; set; }


        [Display(Name = "Alteração")]
        public string? DataAlt
        {
            get { return Data_Alt?.ToShortDateString(); }
        }
    }
}