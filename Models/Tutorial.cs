using System.ComponentModel.DataAnnotations;

namespace asp.netCoreIntro.Models
{
    public class Tutorial
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="name is required")]

        [Display(Name= "Tutorial Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }


    }
}
