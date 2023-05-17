using ProgrammingGroupWebApp.Data.ENUM;
using ProgrammingGroupWebApp.Models;

namespace ProgrammingGroupWebApp.ViewModel
{
    public class MeetUpViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AddLanguage Language { get; set; }
        public IFormFile Image { get; set; }
        public MeetUpCategory meetUpCategory { get; set; }
    }
}
