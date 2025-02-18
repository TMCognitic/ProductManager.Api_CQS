using System.ComponentModel.DataAnnotations;

namespace ProductManager.Api.Models.Dtos
{
    public class ModifieProduitDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; } = default!;

        [Required]
        [Range(0, double.MaxValue)]
        public double Prix { get; set; }
    }
}
