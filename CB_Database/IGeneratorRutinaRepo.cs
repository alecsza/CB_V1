using CB_V1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Database
{
    public class GeneratorRutineRepository : IGeneratorRutineRepository
    {


        private readonly DatabaseContext _databaseContext;

        public GeneratorRutineRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<IEnumerable<string>> GetGeneratorRutineStrAsync()
        {
            try
            {
                var genRutine = await _databaseContext.GeneratorRutina.Select(x => x.ToString()).ToListAsync();
                return genRutine;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<GeneratorRutina>> GetGeneratorRutineAsync()
        {
            try
            {
                var genRutine = await _databaseContext.GeneratorRutina.ToListAsync();
                return genRutine;
            }
            catch (Exception e)
            {
                var mesaj = $"{e.Message} {e.Data} {e.StackTrace}";
                return null;
            }
        }


        public async Task<GeneratorRutina> GetGeneratorRutinaByIdAsync(int id)
        {
            try
            {
                var genRutina = await _databaseContext.GeneratorRutina.FindAsync(id);
                return genRutina;
            }
            catch (Exception e)
            {
                return null;
            }
        }






        public async Task<bool> AddGeneratorRutinaAsync(GeneratorRutina ga)
        {
            try
            {
                var tracking = await _databaseContext.GeneratorRutina.AddAsync(ga);

                await _databaseContext.SaveChangesAsync();
                var isAdded = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Added;
                return isAdded;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public async Task<bool> UpdateGeneratorRutinaAsync(GeneratorRutina ga)
        {
            try
            {
                var tracking = _databaseContext.Update(ga);

                await _databaseContext.SaveChangesAsync();
                var isModified = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Modified;
                return isModified;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public async Task<bool> RemoveGeneratorRutinaAsync(int id)
        {
            try
            {
                var ga = await _databaseContext.GeneratorRutina.FindAsync(id);

                var tracking = _databaseContext.Remove(ga);

                await _databaseContext.SaveChangesAsync();
                var isDeleted = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Deleted;
                return isDeleted;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<GeneratorRutina>> QueryGeneratorRutineAsync(Func<GeneratorRutina, bool> predicate)
        {
            try
            {
                var genRutine = _databaseContext.GeneratorRutina.Where(predicate);
                return genRutine.ToList();
            }
            catch (Exception e)
            {
                return null;
            }


        }


    }
}
