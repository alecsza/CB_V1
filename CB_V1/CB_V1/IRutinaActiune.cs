using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CB_V1
{
    public interface IRutinaActiuniRepository
    {
        Task<IEnumerable<RutinaActiune>> GetRutinaActiuniAsync();

        Task<IEnumerable<string>> GetRutinaActiuniStrAsync();

        Task<RutinaActiune> GetRutinaActiuneByIdAsync(int Id);

        Task<bool> AddRutinaActiuneAsync(RutinaActiune ra);

        Task<bool> UpdateRutinaActiuneAsync(RutinaActiune ra);

        Task<bool> RemoveRutinaActiuneAsync(int id);

        Task<IEnumerable<RutinaActiune>> QueryRutinaActiuniAsync(Func<RutinaActiune, bool> predicate);
    }
}
