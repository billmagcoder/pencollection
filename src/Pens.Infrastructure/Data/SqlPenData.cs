using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pens.Core.Models;
using Pens.Core.Services;

namespace Pens.Infrastructure.Data
{
    public class SqlPenData : IPen
    {
        private readonly PenDbContext _db;

        public SqlPenData(PenDbContext db)
        {
            _db = db;
        }

        public async Task AddPen(Pen pen)
        {
            await _db.AddAsync(pen);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Pen>> GetAll()
        {
            return await _db.Pens.ToListAsync();
        }

        public async Task<Pen> GetPen(int id)
        {
            return await _db.Pens.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdatePen(Pen pen)
        {
            // use optimistic concurrency
            var entry = _db.Entry(pen); // new entry for EF to track
            entry.State = EntityState.Modified; // current state is in modified state
            await _db.SaveChangesAsync();
        }

        public async Task DeletePen(int id)
        {
            var result = await _db.Pens.FindAsync(id);
            _db.Pens.Remove(result);
            await _db.SaveChangesAsync();
        }
    }
}
