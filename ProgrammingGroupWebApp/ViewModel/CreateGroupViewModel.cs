using ProgrammingGroupWebApp.Data.ENUM;
using ProgrammingGroupWebApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammingGroupWebApp.ViewModel
{
    public class CreateGroupViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AddLanguage Language { get; set; }
        public IFormFile Image { get; set; }
        public GroupCategory GroupCategory { get; set; }
    }
}
