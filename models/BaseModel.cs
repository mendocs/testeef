
using System.ComponentModel.DataAnnotations;

namespace testeef.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Este Campo é obrigatório")]
        [MaxLength (60, ErrorMessage = "Este campo deve conter entre 3 e 60 caraceres")]
        [MinLength (3, ErrorMessage = "Este campo deve conter entre 3 e 60 caraceres")]
        public string Title { get; set; }

    }
}