using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PrecisoPRO.Models.ViewModels
{
    public class EmpresaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo RAZÃO é obrigatório.")]
        public required string Razao { get; set; }

        [Required(ErrorMessage = "O campo FANTASIA é obrigatório.")]
        public required string Fantasia { get; set; }

        public string? Endereco { get; set; }

        public string? Numero { get; set; }

        public string? Cidade { get; set; }

        public string? UF { get; set; }

        public string? Cep { get; set; }

        public string? Bairro { get; set; }

       
        [EmailAddress(ErrorMessage = "O campo Email não está em um formato válido.")]
        public string? Email { get; set; }


        public string? Ie { get; set; }

        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
        public required string Cnpj { get; set; }


      
        public string? Celular { get; set; }
        public string? Telefone { get; set; }


        public sbyte Status { get; set; }
        public sbyte Principal { get; set; }
        public DateTime? Data_Cad { get; set; }

              
        public DateTime? Data_Alt { get; set; }

       
    }
}
