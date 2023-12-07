using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//associar a empresa ao estado para emitir a cnd
namespace PrecisoPRO.Models.ViewModels
{
    public class AssociarEmpUFViewModel
    {
        //DA TABELA EMITIRCND
        [Key]
        [Column("ID")]
        public int IdRegistro { get; set; }

        [Column("ID_EMPRESA")]
        public int IdEmpresa { get; set; }


        [Column("ID_ESTADO")]
        public int IdEstado { get; set; }


        [Column("OBS")]
        public string? Obs { get; set; }

        public DateTime? Data_Cad { get; set; }
    }
}
