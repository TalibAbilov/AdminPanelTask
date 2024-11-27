using System.ComponentModel.DataAnnotations;

namespace CoffeeTask.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required,StringLength(10,ErrorMessage ="Max uz 10 min uzunluq 3 ",MinimumLength =3 )]
        
        public string Name { get; set; }
        public List<Product>?products { get; set; }
    }
}
