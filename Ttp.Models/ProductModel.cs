using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplicationTEST.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Author")]
        public string Author { get; set; }

        [Required]
        [DisplayName("List Price")]
        public double Price { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public CategoryModel Category { get; set; }

        [ValidateNever]
        public string ImgUrl { get; set; }

    }
}
