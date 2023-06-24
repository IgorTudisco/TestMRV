using System.ComponentModel.DataAnnotations;

namespace TestMRV.Models
{
    public class Card
    {
        [Key]
        [Required(ErrorMessage = "Campo CardId é obrigatório")]
        public int CardId { get; set; }

        [Required(ErrorMessage = "Campo FirstName é obrigatório")]
        public string? FirstName { get; set; }        

        [Required(ErrorMessage = "Campo Suburb é obrigatório")]
        public string? Suburb { get; set; }

        [Required(ErrorMessage = "Campo Category é obrigatório")]
        public string? Category { get; set; }        

        [Required(ErrorMessage = "Campo Description é obrigatório")]
        [MaxLength(250, ErrorMessage = "O tamanho da Descrição não pode passar de 250 caracteres")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Campo Price é obrigatório")]
        [Range(0.01, 1000000.00, ErrorMessage = "O preço deve estar entre 0,01 e 1.000.000,00")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Campo DateCreated é obrigatório")]
        public string DateCreated { get; set; } = DateTime.Now.ToString("MMMM dd hh:mm");

        [Required(ErrorMessage = "Campo Accept é obrigatório")]
        public bool Accept { get; set; } = false;

    }
}
