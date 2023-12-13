using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PrecisoPRO.Models.ViewModels
{
    public class EmpresaViewModel
    {
       
  
        public int Id { get; set; }

      
        public string? Ie { get; set; }

        public string? Im { get; set; }

      
        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
        public required string Cnpj { get; set; }


       
        [Required(ErrorMessage = "O campo RAZÃO é obrigatório.")]
        public required string Razao { get; set; }


        public string? NMei { get; set; }


        [Required(ErrorMessage = "O campo FANTASIA é obrigatório.")]
        public required string Fantasia { get; set; }



        public int? NatJuridica { get; set; }

        public int? RegJuridico { get; set; }



        public string? AtvPrincipal { get; set; }

        public string? Cep { get; set; }

        public string? Endereco { get; set; }

        public string? Numero { get; set; }


        public string? Complemento { get; set; }

        public string? Bairro { get; set; }


        public string? Cidade { get; set; }

        [Required(ErrorMessage = "O campo ESTADO é obrigatório.")]
        public string? UF { get; set; }


   
        public string? Referencia { get; set; }



        public sbyte Principal { get; set; }


        public string? Telefone { get; set; }

        public string? Celular { get; set; }


        public string? Email { get; set; }

  
      

        public DateTime? Data_Cad { get; set; }

       
        public DateTime? Data_Alt { get; set; }


        public string? SitCadastral { get; set; }



        public string? MotDescCred { get; set; }

        //A sigla NIRE significa Número de Identificação do Registro de Empresas. É ele quem comprova que a empresa existe oficialmente
        public string? Nire { get; set; }

   
        public string? NomeContador { get; set; }

        public string? CrcContador { get; set; }

   
        public string? NomeResponsavel { get; set; }


        public string? CrcResponsavel { get; set; }


        public string? TelAlternativo { get; set; }

    
        public string? CelAlternativo { get; set; }

  
        public string? EmailAlternativo { get; set; }

 
        public string? LoginDteSefaz { get; set; }

   
        public string? SenhaDteSefaz { get; set; }

      
        public string? CpfRepresentante { get; set; }

        public string? Anotacoes { get; set; }




    }
}
