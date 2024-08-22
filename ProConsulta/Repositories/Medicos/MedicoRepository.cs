using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Medicos
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Medico medico)
        {
            try
            {
                _context.Medicos.Add(medico);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                _context.ChangeTracker.Clear();
                throw;
            }
            
        }

        public async Task DeleteByIdAsync(int id)
        {
            var medico = await GetByIdAsync(id);
            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Medico>> GetAllAsync()
        {
            return await _context
                .Medicos
                .Include(x => x.Especialidade)
                .AsNoTracking()
                .ToListAsync();

        }

        public async Task<Medico?> GetByIdAsync(int id)
        {
            return await _context
                .Medicos
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Medico medico)
        {
            try
            {
                _context.Update(medico);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                _context.ChangeTracker.Clear();
                throw;
            }
            
        }
    }
}
