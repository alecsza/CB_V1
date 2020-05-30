using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CB_V1
{
    public interface IGeneratorRutineRepository
    {
        Task<IEnumerable<GeneratorRutina>> GetGeneratorRutineAsync();

        Task<IEnumerable<string>> GetGeneratorRutineStrAsync();

        Task<GeneratorRutina> GetGeneratorRutinaByIdAsync(int Id);

        Task<bool> AddGeneratorRutinaAsync(GeneratorRutina gr);

        Task<bool> UpdateGeneratorRutinaAsync(GeneratorRutina gr);

        Task<bool> RemoveGeneratorRutinaAsync(int id);

        Task<IEnumerable<GeneratorRutina>> QueryGeneratorRutineAsync(Func<GeneratorRutina, bool> predicate);
    }
}
