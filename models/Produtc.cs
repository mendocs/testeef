
using System.ComponentModel.DataAnnotations;

namespace testeef.Models
{
    public class Product : BaseModel
    {


        public Product(){}
        public Product(string description, decimal price, Category category, string title)
        {
            this.Title = title;
            this.Description = description;
            this.Price = price;
            //this.Categoryid = categoryid;
            this.Category = category;

        }


        [MaxLength(1024, ErrorMessage = "Este campo deve conter máximo 1024")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Este Campo é obrigatório")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "Este Campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria Inválida")]
        public int Categoryid { get; set; }
        public Category Category { get; set; }


    }
}