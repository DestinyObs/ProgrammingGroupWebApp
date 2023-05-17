using ProgrammingGroupWebApp.Data.ENUM;
using ProgrammingGroupWebApp.Models;

namespace ProgrammingGroupWebApp.ViewModel
{
    public class EditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
        public AddLanguage Language { get; set; }
        public int LangId { get; set; }

        public GroupCategory GroupCategory { get; set; }

    }
}
