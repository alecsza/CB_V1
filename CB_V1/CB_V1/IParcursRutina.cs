using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CB_V1
{
    public interface IParcursRutineRepository
    {
        Task<IEnumerable<ParcursRutina>> GetParcursRutineAsync();

        Task<IEnumerable<string>> GetParcursRutineStrAsync();

        Task<ParcursRutina> GetParcursRutinaByIdAsync(int Id);

        Task<bool> AddParcursRutinaAsync(ParcursRutina pa);

        Task<bool> UpdateParcursRutinaAsync(ParcursRutina pa);

        Task<bool> RemoveParcursRutinaAsync(int id);

        Task<IEnumerable<ParcursRutina>> QueryParcursRutineAsync(Func<ParcursRutina, bool> predicate);
    }
}
