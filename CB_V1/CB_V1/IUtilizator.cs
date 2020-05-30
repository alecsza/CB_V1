using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CB_V1
{
    public interface IUtilizatoriRepository
    {
        Task<IEnumerable<Utilizator>> GetUtilizatoriAsync();

        Task<IEnumerable<string>> GetUtilizatoriStrAsync();

        Task<Utilizator> GetUtilizatorByIdAsync(int Id);

        Task<bool> AddUtilizatorAsync(Utilizator util);

        Task<bool> UpdateUtilizatorAsync(Utilizator util);

        Task<bool> RemoveUtilizatorAsync(int id);

        Task<IEnumerable<Utilizator>> QueryUtilizatoriAsync(Func<Utilizator, bool> predicate);
    }
}
