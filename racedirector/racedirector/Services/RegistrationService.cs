using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using racedirector.Data;
using racedirector.Data.Models;

namespace racedirector.Services
{
    public interface IRegistrationService
    {
        Task<List<RaceEntry>> Get();
        Task<RaceEntry> Get(int id);
        Task<RaceEntry> Add(RaceEntry re);
        Task<RaceEntry> Update(RaceEntry re);
        Task<RaceEntry> Delete(RaceEntry id);
    }
    public class RegistrationService : IRegistrationService
    {
        private readonly ApplicationDbContext _context;

        public RegistrationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RaceEntry>> Get()
        {
            var entrys = new List<RaceEntry>();

            try
            {
                entrys = await _context.RaceEntries
                                        .Include(entry => entry.Driver)
                                        .Include(ent => ent.Car)
                                        .Include(ent => ent.Class)
                                        .Include(ent => ent.PaxClass)
                                        .ToListAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Exception occurred: {e}");
            }

            return entrys;
        }

        public async Task<RaceEntry> Get(int id)
        {
            var re = await _context.RaceEntries.FindAsync(id);

            return re;
        }

        public async Task<RaceEntry> Add(RaceEntry re)
        {
            _context.RaceEntries.Add(re);
            await _context.SaveChangesAsync();
            return re;
        }
        public async Task<RaceEntry> Update(RaceEntry re)
        {
            _context.Entry(re).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return re;
        }

        public async Task<RaceEntry> Delete(RaceEntry id)
        {
            var re = await _context.RaceEntries.FindAsync(id);
            _context.RaceEntries.Remove(re);
            await _context.SaveChangesAsync();
            return re;
        }
    }
}
