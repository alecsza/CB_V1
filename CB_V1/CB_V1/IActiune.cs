using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CB_V1
{
    public interface IActiuniRepository
    {
        Task<IEnumerable<Actiune>> GetActiuniAsync();

        Task<IEnumerable<string>> GetActiuniStrAsync();

        Task<Actiune> GetActiuneByIdAsync(int Id);

        Task<Actiune> GetActiuneByNameAsync(string Name);

        Task<bool> AddActiuneAsync(Actiune act);

        Task<bool> UpdateActiuneAsync(Actiune act);

        Task<bool> RemoveActiuneAsync(int id);

        Task<IEnumerable<Actiune>> QueryActiuniAsync(Func<Actiune, bool> predicate);
    }
}
