
using System.ComponentModel.DataAnnotations;

namespace testeef.Models
{
    public class Category : BaseModel
    {

        public Category(){}
        public Category(int id, string title) 
        {
            this.Id = id;
            this.Title = title;
               
        }

        /*
        [Key]
        
                public int Id { get; set; }

        [Required (ErrorMessage = "Este Campo é obrigatório")]
        [MaxLength (60, ErrorMessage = "Este campo deve conter entre 3 e 60 caraceres")]
        [MinLength (60, ErrorMessage = "Este campo deve conter entre 3 e 60 caraceres")]
        public string Title { get; set; }
        */

    }
}