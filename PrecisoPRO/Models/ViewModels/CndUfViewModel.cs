using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/*CLASSE QUE REPRESENTA UMA VIEW NO BANCO DE DADOS, NO CASO QUE MOSTRA DAS AS EMPRESAS QUE TEM ESTADOS MARCADOS PARA EMITIR CND*/
namespace PrecisoPRO.Models.ViewModels
{
    [Table("EMITIR_CNDUF")]
    public class CndUfViewModel
    {
        //DA TABELA EMITIRCND
        [Key]
        [Column("ID_REGISTRO")]
        public int IdRegistro { get; set; }

        [Column("ID_EMPRESA")]
        public int IdEmpresa { get; set; }


        [Column("ID_ESTADO")]
        public int IdEstado { get; set; }


        [Column("OBS")]
        public string? Obs { get; set; }

        //DA TABELA EMPRESA

        [Column("ID_NA_EMPRESA")]
        public int IdNaEmpresa { get; set; }


        [Column("RAZAO_SOCIAL")]
        public string? RazaoSocial { get; set; }


        [Column("FANTASIA")]
        public string? Fantasia { get; set; }

        [Column("CIDADE")]
        public string? Cidade { get; set; }

        [Column("UF_EMPRESA")]
        public string? UfEmpresa { get; set; }

        [Column("CNPJ")]
        public string? Cnpj { get; set; }

        [Column("IE")]
        public string? Ie { get; set; }

        [Column("ATIVA")]
        public sbyte Ativa { get; set; }

        //DA TABELA ESTADO

        [Column("NOME_ESTADO")]
        public string? NomeEstado { get; set; }


        [Column("UF_DO_ESTADO")]
        public string? UFEstado { get; set; }

        [Column("BANDEIRA")]
        public string? Bandeira { get; set; }




    }
}
