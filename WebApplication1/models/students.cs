using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace WebApplication1.models
{
    public class Students
    {


        [Required]
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }

        [RegularExpression("Computer Science|Information System|Computer Engineering")]
        public string Major { get; set; }

        [Range(1, 99)]
        public int Age { get; set; }

        [MinLength(1)]
        public List<string> Hobbies { get; set; } = new List<string>();
    }


}
