using System.ComponentModel.DataAnnotations;

namespace WebApplication1.models
{
    public class products
    {
  
        public string Name { get; set; }


        [Range(0, 1000)]
        public double Price { get; set; }

        public string Email { get; set; }
    }
}
