using System.ComponentModel.DataAnnotations;

namespace ProgrammingGroupWebApp.Models
{
    public class AddLanguage
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; } 

        public string Description { get; set; }
        public string City { get; set; }


    }
}
