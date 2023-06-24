using System.ComponentModel.DataAnnotations;

namespace TestMRV.Data.Dtos
{
    public class ReadCardDTO
    {
        public string? FirstName { get; set; }
        public string? Suburb { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public string DateCreated { get; set; }
        public bool Accept { get; set; }
    }
}
