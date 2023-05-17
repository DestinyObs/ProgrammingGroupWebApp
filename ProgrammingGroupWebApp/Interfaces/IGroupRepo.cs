using ProgrammingGroupWebApp.Models;

namespace ProgrammingGroupWebApp.Interfaces
{
    public interface IGroupRepo
    {
        Task<IEnumerable<Group>> GetAll();  
        Task<Group> GetByIdAync(int id);
        Task<Group> GetByIdAyncNoTracking(int id);
        Task<IEnumerable<Group>> GetGroupByCity(string  city);
        bool Add(Group group);
        bool Update(Group group);
        bool Delete(Group group);
        bool save();



    }
}
