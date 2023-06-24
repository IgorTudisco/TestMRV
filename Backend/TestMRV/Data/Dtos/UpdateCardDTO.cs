using System.ComponentModel.DataAnnotations;

namespace TestMRV.Data.Dtos
{
    public class UpdateCardDTO
    {
        [Required(ErrorMessage = "Campo FirstName é obrigatório")]
        public string? FirstName { get; set; }

        //public DateTime DateCreated { get; set; }
        [Required(ErrorMessage = "Campo Suburb é obrigatório")]
        public string? Suburb { get; set; }

        [Required(ErrorMessage = "Campo Category é obrigatório")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "Campo Description é obrigatório")]
        [StringLength(250, ErrorMessage = "O tamanho dá descrição não pode passar de 250 caracteres")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Campo Price é obrigatório")]
        [Range(0.01, 1000000.00, ErrorMessage = "O preço deve estar entre 0,01 e 1.000.000,00")]
        public float Price { get; set; }
    }
}
