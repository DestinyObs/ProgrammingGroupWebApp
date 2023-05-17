using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;
using ProgrammingGroupWebApp.Data.ENUM;

namespace ProgrammingGroupWebApp.Models
{
    public class Group
    {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [ForeignKey("Language")]
        public int LangId { get; set; }
        public AddLanguage? Language { get; set; }
        public GroupCategory GroupCategory { get; set; }
        [ForeignKey("AppUser")]
        public string? UserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
