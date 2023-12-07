using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Xml.Linq;

namespace PrecisoPRO.Models
{
    [Table("EMPRESA")]
    public class Empresa
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        [Column("ID")]
        public int Id { get; set; }


        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "O campo RAZÃO é obrigatório.")]
        [Column("RAZAO")]
        public required string Razao { get; set; }

        [Display(Name = "Fantasia")]
        [Required(ErrorMessage = "O campo FANTASIA é obrigatório.")]
        [Column("FANTASIA")]
        public required string Fantasia { get; set; }

        [Display(Name = "Endereço")]
        [Column("ENDERECO")]
        public  string? Endereco { get; set; }

        [Display(Name = "E-Mail")]
        [EmailAddress(ErrorMessage = "O campo Email não está em um formato válido.")]
        [Column("EMAIL")]
        public  string? Email { get; set; }

        [Display(Name = "Número")]
        [Column("NUMERO")]
        public string? Numero { get; set; }

        [Display(Name = "Cidade")]
        [Column("CIDADE")]
        public string? Cidade { get; set; }

        [Display(Name = "Estado")]
        [Column("ESTADO")]
        public string? UF { get; set; }

        [Display(Name = "CEP")]
        [Column("CEP")]
        public string? Cep { get; set; }

        [Display(Name = "Bairro")]
        [Column("BAIRRO")]
        public string? Bairro { get; set; }



        [Display(Name = "Insc. Estadual")]
        [Column("IE")]
        public  string? Ie { get; set; }


        [Display(Name = "Cnpj")]
        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
        [Column("CNPJ")]
        public required string Cnpj { get; set; }


        [Display(Name = "Celular")]
        [Column("CELULAR")]
        public string? Celular { get; set; }

        [Display(Name = "Telefone")]
        [Column("TELEFONE")]
        public string? Telefone { get; set; }

        [Display(Name = "Status")]
        [Column("STATUS")]
        public sbyte Status { get; set; }

        [Display(Name = "Principal")]
        [Column("PRINCIPAL")]
        public sbyte Principal { get; set; }

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

        public ICollection<Usuario>? Usuarios { get; set; }
       
    }
}
