using CB_V1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Database
{
    public class ParcursRutineRepository : IParcursRutineRepository
    {


        private readonly DatabaseContext _databaseContext;

        public ParcursRutineRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<IEnumerable<string>> GetParcursRutineStrAsync()
        {
            try
            {
                var genRutine = await _databaseContext.ParcursRutina.Select(x => x.ToString()).ToListAsync();
                return genRutine;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ParcursRutina>> GetParcursRutineAsync()
        {
            try
            {
                var genRutine = await _databaseContext.ParcursRutina.ToListAsync();
                return genRutine;
            }
            catch (Exception e)
            {
                var mesaj = $"{e.Message} {e.Data} {e.StackTrace}";
                return null;
            }
        }


        public async Task<ParcursRutina> GetParcursRutinaByIdAsync(int id)
        {
            try
            {
                var genRutina = await _databaseContext.ParcursRutina.FindAsync(id);
                return genRutina;
            }
            catch (Exception e)
            {
                return null;
            }
        }






        public async Task<bool> AddParcursRutinaAsync(ParcursRutina pr)
        {
            try
            {
                var tracking = await _databaseContext.ParcursRutina.AddAsync(pr);

                await _databaseContext.SaveChangesAsync();
                var isAdded = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Added;
                return isAdded;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public async Task<bool> UpdateParcursRutinaAsync(ParcursRutina pr)
        {
            try
            {
                var tracking = _databaseContext.Update(pr);

                await _databaseContext.SaveChangesAsync();
                var isModified = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Modified;
                return isModified;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public async Task<bool> RemoveParcursRutinaAsync(int id)
        {
            try
            {
                var pr = await _databaseContext.ParcursRutina.FindAsync(id);

                var tracking = _databaseContext.Remove(pr);

                await _databaseContext.SaveChangesAsync();
                var isDeleted = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Deleted;
                return isDeleted;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ParcursRutina>> QueryParcursRutineAsync(Func<ParcursRutina, bool> predicate)
        {
            try
            {
                var genRutine = _databaseContext.ParcursRutina.Where(predicate);
                return genRutine.ToList();
            }
            catch (Exception e)
            {
                return null;
            }


        }



     

     
    }
}
