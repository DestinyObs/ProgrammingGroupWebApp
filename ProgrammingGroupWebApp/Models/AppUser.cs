using Microsoft.AspNetCore.Identity;
using ProgrammingGroupWebApp.Data.ENUM;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammingGroupWebApp.Models
{
    public class AppUser : IdentityUser
    {

        public string? UserName { get; set; }
        public AddLanguage? Language { get; set; }
        [ForeignKey("Language")]
        public int LangId { get; set; }

        public ICollection<Group> groups { get; set; }
        public ICollection<CodingMeetUp> codingMeetUps { get; set; }

    }
}
    