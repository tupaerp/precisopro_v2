using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrecisoPRO.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        [Column("ID")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo NOME é obrigatório.")]
        [Column("NOME")]
        public required string Nome { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "O campo LOGIN é obrigatório.")]
        [Column("LOGIN")]
        public required string Login { get; set; }


        [Display(Name = "Celular")]
        [Column("CELULAR")]
        public string? Celular { get; set; }

        [Required(ErrorMessage = "O campo SENHA é obrigatório.")]
        [DataType(DataType.Password)]
        [Column("SENHA")]
        public string Senha { get; set; }

        [Display(Name = "E-Mail")]
        [EmailAddress(ErrorMessage = "O campo Email não está em um formato válido.")]
        [Required(ErrorMessage = "O campo E-MAIL é obrigatório.")]
        [Column("EMAIL")]
        public required string Email { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "O campo EMPRESA é obrigatório.")]
        [ForeignKey("Empresa")]
        [Column("ID_EMPRESA")]
        public int? EmpresaId { get; set; }

        public Empresa? Empresa { get; set; }


        //[Display(Name = "Imagem")]
        //public string? Imagem { get; set; }



        [Display(Name = "Status")]
        [Column("STATUS")]
        public sbyte Status { get; set; }

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
