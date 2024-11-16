using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortifolioRuizPereira.Models
{
    public class Usuario
    {
        public required int ID { get; set; }
        public required string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

   
        [StringLength(8, MinimumLength = 4, ErrorMessage = "A senha deve ter entre 4 e 8 caracteres.")]
        public required string Password { get; set; }

        [BindNever]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string? Role { get; set; }
    }
}
