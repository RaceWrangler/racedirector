using Microsoft.EntityFrameworkCore;
using racedirector.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using racedirector.Data;

namespace racedirector.Services
{
    public interface IClassificationService
    {
        Task<List<Classification>> Get();
        Task<Classification> Get(int id);
        Task<Classification> Add(Classification cls);
        Task<Classification> Update(Classification cls);
        Task<Classification> Delete(Classification id);
    }

    public class ClassificationService : IClassificationService
    {
        private readonly ApplicationDbContext _context;

        public ClassificationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Classification>> Get()
        {
            var classes = new List<Classification>();
            try
            {
                classes = await _context.Classes.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occurred: {e}");
            }
            return classes;
        }

        public async Task<Classification> Get(int id)
        {
            var cls = await _context.Classes.FindAsync(id);
            return cls;
        }

        public async Task<Classification> Add(Classification cls)
        {
            _context.Classes.Add(cls);
            await _context.SaveChangesAsync();
            return cls;
        }

        public async Task<Classification> Update(Classification cls)
        {
            _context.Entry(cls).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cls;
        }

        public async Task<Classification> Delete(Classification id)
        {
            var cls = await _context.Classes.FindAsync(id);
            _context.Classes.Remove(cls);
            await _context.SaveChangesAsync();
            return cls;
        }
    }
}
