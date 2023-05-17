using ProgrammingGroupWebApp.Models;

namespace ProgrammingGroupWebApp.Interfaces
{
    public interface IMeetRepo
    {
        Task<IEnumerable<CodingMeetUp>> GetAll();
        Task<CodingMeetUp> GetByIdAync(int id);
        Task<CodingMeetUp> GetByIdAyncNoTracking(int id);
        Task<IEnumerable<CodingMeetUp>> GetAllCodingMeetUpsByCity(string city);
        bool Add(CodingMeetUp codingMeetUp);
        bool Update(CodingMeetUp codingMeetUp);
        bool Delete(CodingMeetUp codingMeetUp);
        bool save();

    }
}
