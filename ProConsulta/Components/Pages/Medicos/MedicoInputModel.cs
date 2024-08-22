using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Medicos
{
    public class MedicoInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} deve ser fornecido")]
        [MaxLength(50, ErrorMessage ="{0} deve conter no máximo {1} caracteres")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public string Documento { get; set; } = null!;

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public string Crm { get; set; } = null!;

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public string Celular { get; set; } = null!;

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Valor selecionado é inválido")]
        public int EspecialidadeId { get; set; }
    }
}
