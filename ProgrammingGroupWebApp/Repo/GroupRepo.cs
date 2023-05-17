using Microsoft.EntityFrameworkCore;
using ProgrammingGroupWebApp.Data;
using ProgrammingGroupWebApp.Interfaces;
using ProgrammingGroupWebApp.Models;

namespace ProgrammingGroupWebApp.Repo
{
    public class GroupRepo : IGroupRepo
    {
        private readonly AppDbContext _context;

        public GroupRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool Add(Group group)
        {
           _context.Add(group);
            return save();
        }

        public bool Delete(Group group)
        {
           _context.Remove(group);
            return save();
        }

        public async Task<IEnumerable<Group>> GetAll()
        {
            return  await _context.groups.ToListAsync();
        }

        public async Task<Group> GetByIdAync(int id)
        {
            return await _context.groups.Include(i => i.Language).FirstOrDefaultAsync(x => x.Id == id);   
        }

        public async Task<Group> GetByIdAyncNoTracking(int id)
        {
            return await _context.groups.Include(i => i.Language).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Group>> GetGroupByCity(string city)
        {
            return await _context.groups.Where(c => c.Language.City.Contains(city)).ToListAsync();
        }

        public bool save()
        {
            var saved  = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Group group)
        {
            _context.Update(group);
            return save();
        }
    }
}
