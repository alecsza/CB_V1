using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CB_V1
{
    public interface IRutineRepository
    {
        Task<IEnumerable<Rutina>> GetRutineAsync();

        Task<IEnumerable<string>> GetRutineStrAsync();

        Task<Rutina> GetRutinaByIdAsync(int Id);

        Task<bool> AddRutinaAsync(Rutina rut);

        Task<bool> UpdateRutinaAsync(Rutina rut);

        Task<bool> RemoveRutinaAsync(int id);

        Task<IEnumerable<Rutina>> QueryRutineAsync(Func<Rutina, bool> predicate);
    }
}
