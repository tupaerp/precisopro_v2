using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;
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

        [Display(Name = "Insc. Estadual")]
        [Column("IE")]
        public string? Ie { get; set; }

        [Display(Name = "Insc. Municipal")]
        [Column("IM")]
        public string? Im { get; set; }

        [Display(Name = "Cnpj")]
        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
        [Column("CNPJ")]
        public required string? Cnpj { get; set; }


        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "O campo RAZÃO é obrigatório.")]
        [Column("RAZAO")]
        public required string? Razao { get; set; }

        [Display(Name = "Número MEI")]
        [Column("N_MEI")]
        public  string? NMei { get; set; }

        [Display(Name = "Fantasia")]
        [Required(ErrorMessage = "O campo FANTASIA é obrigatório.")]
        [Column("FANTASIA")]
        public required string? Fantasia { get; set; }


        [Display(Name = "Natureza Jurídica")]
        [ForeignKey("NaurezaJuridica")]
        [Column("NAT_JURIDICA")]
        public int? NatJuridica { get; set; }

        //foreignkey
        public NaturezaJuridica? NaurezaJuridica;

        [Display(Name = "Regime Jurídico")]
        [ForeignKey("RegimeJuridico")]
        [Column("REG_JURIDICO")]
        public int? RegJuridico { get; set; }
        public RegimeJuridico? RegimeJuridico { get; set; }




        [Display(Name = "Atividade Principal")]
        [Column("ATV_PRINCIPAL")]
        public string? AtvPrincipal { get; set; }

        [Display(Name = "CEP")]
        [Column("CEP")]
        public string? Cep { get; set; }

        [Display(Name = "Logradouro")]
        [Column("ENDERECO")]
        public  string? Endereco { get; set; }

        [Display(Name = "Número")]
        [Column("NUMERO")]
        public string? Numero { get; set; }

        [Display(Name = "Complemento")]
        [Column("COMPLEMENTO")]
        public string? Complemento { get; set; }

        [Display(Name = "Bairro")]
        [Column("BAIRRO")]
        public string? Bairro { get; set; }

        [Display(Name = "Cidade")]
        [Column("CIDADE")]
        public string? Cidade { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "O campo ESTADO é obrigatório.")]
        [Column("ESTADO")]
        public string? UF { get; set; }


        [Display(Name = "Referência")]
        [Column("REFERENCIA")]
        public string? Referencia { get; set; }


        //identifica a empresa como sendo a monitora de todas as outras
        [Display(Name = "Principal")]
        [Column("PRINCIPAL")]
        public sbyte? Principal { get; set; }


        [Display(Name = "Telefone")]
        [Column("TELEFONE")]
        public string? Telefone { get; set; }

        [Display(Name = "Celular")]
        [Column("CELULAR")]
        public string? Celular { get; set; }


        [Display(Name = "E-Mail")]
        [EmailAddress(ErrorMessage = "O campo Email não está em um formato válido.")]
        [Column("EMAIL")]
        public  string? Email { get; set; }
              
        // ***************** DADOS INTERNOS DE CONTROLE ****************************************
      


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

        // ************************************************************************************


        [Display(Name = "Situação Cadastral")]
        [Column("SIT_CADASTRAL")]
        public string? SitCadastral { get; set; }



        [Display(Name = "Motivo do Credenciamento/Descrendenciamento")]
        [Column("MOT_CREDENCIA_DESCRE")]
        public string? MotDescCred { get; set; }

        //A sigla NIRE significa Número de Identificação do Registro de Empresas. É ele quem comprova que a empresa existe oficialmente
        [Display(Name = "Número do Nire")]
        [Column("N_NIRE")]
        public string? Nire { get; set; }

        [Display(Name = "Nome do Contador")]
        [Column("NOME_CONTADOR")]
        public string? NomeContador { get; set; }

        [Display(Name = "CRC do Contador")]
        [Column("CRC_CONTADOR")]
        public string? CrcContador { get; set; }

        [Display(Name = "Nome do Responsável")]
        [Column("NOME_RESPONSAVEL")]
        public string? NomeResponsavel { get; set; }

        [Display(Name = "CRC do Responsavel")]
        [Column("CRC_RESPONSAVEL")]
        public string? CrcResponsavel { get; set; }

        [Display(Name = "Telefone alternativo")]
        [Column("TEL_ALTERNATIVO")]
        public string? TelAlternativo { get; set; }

        [Display(Name = "Celular Alternativo")]
        [Column("CEL_ALTERNATIVO")]
        public string? CelAlternativo { get; set; }

        [Display(Name = "E-Mail Alternativo")]
        [Column("EMAIL_ALTERNATIVO")]
        public string? EmailAlternativo { get; set; }

        [Display(Name = "Login Dte Sefaz")]
        [Column("LOGIN_DTE_SEFAZ")]
        public string? LoginDteSefaz { get; set; }

        [Display(Name = "Senha DTE Sefaz")]
        [Column("SENHA_DTE_SEFAZ")]
        public string? SenhaDteSefaz { get; set; }

        [Display(Name = "Cpf do Representante")]
        [Column("CPF_REPRESENTANTE")]
        public string? CpfRepresentante { get; set; }

        [Display(Name = "Anotações")]
        [Column("ANOTACOES")]
        public string? Anotacoes { get; set; }

        public ICollection<Usuario>? Usuarios { get; set; }

     
        
    }
}
