using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PrecisoPRO.Models.ViewModels
{
    public class UsuarioViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo NOME é obrigatório.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O campo LOGIN é obrigatório.")]
        public required string Login { get; set; }

        public string? Celular { get; set; }

        [Required(ErrorMessage = "O campo SENHA é obrigatório.")]
        public required string Senha { get; set; }

        [Required(ErrorMessage = "O campo CONFIRMAR SENHA é obrigatório.")]
        [Compare("Senha", ErrorMessage = "As senhas não coincidem")]
        public string? ConfirmarSenha { get; set; }

        [Required(ErrorMessage = "O campo EMAIL é obrigatório.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O campo EMPRESA é obrigatório.")]
        public int? EmpresaId { get; set; }



        public string? URL { get; set; }

        public sbyte Status { get; set; }

        public DateTime? Data_Cad { get; set; }

        public DateTime? Data_Alt { get; set; }


    }
}