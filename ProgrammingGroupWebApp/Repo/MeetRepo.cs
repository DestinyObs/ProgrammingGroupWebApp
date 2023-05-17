using Microsoft.EntityFrameworkCore;
using ProgrammingGroupWebApp.Data;
using ProgrammingGroupWebApp.Interfaces;
using ProgrammingGroupWebApp.Models;

namespace ProgrammingGroupWebApp.Repo
{
    public class MeetRepo : IMeetRepo
    {
        private readonly AppDbContext _context;

        public MeetRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(CodingMeetUp codingMeetUp)
        {
            _context.Add(codingMeetUp);
            return save();
        }

        public bool Delete(CodingMeetUp codingMeetUp)
        {
            _context.Remove(codingMeetUp);
            return save();
        }

        public async Task<IEnumerable<CodingMeetUp>> GetAll()
        {
            return await _context.codingMeetUps.ToListAsync();
        }

        public async Task<IEnumerable<CodingMeetUp>> GetAllCodingMeetUpsByCity(string city)
        {
            return await _context.codingMeetUps.Where(c => c.Language.City.Contains(city)).ToListAsync();
        }

        public async Task<CodingMeetUp> GetByIdAync(int id)
        {
            return await _context.codingMeetUps.Include(i => i.Language).FirstOrDefaultAsync(x => x.Id == id);

        }
        public async Task<CodingMeetUp> GetByIdAyncNoTracking(int id)
        {
            return await _context.codingMeetUps.Include(i => i.Language).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        }


        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(CodingMeetUp codingMeetUp)
        {
            _context.Update(codingMeetUp);
            return save();

        }
    }
}
