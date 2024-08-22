using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Pacientes
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ApplicationDbContext _context;

        public PacienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var paciente = await GetByIdAsync(id);
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Paciente>> GetAllAsync()
        {
            return await _context
                .Pacientes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Paciente?> GetByIdAsync(int id)
        {
            return await _context
                .Pacientes
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            _context.Update(paciente);
            await _context.SaveChangesAsync();
        }
    }
}
