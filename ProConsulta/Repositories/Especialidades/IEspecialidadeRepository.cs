using ProConsulta.Models;

namespace ProConsulta.Repositories.Especialidades
{
    public interface IEspecialidadeRepository
    {
        Task<List<Especialidade>> GetAllAsync();
    }
}
