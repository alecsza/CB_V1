using CB_V1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Database
{
    public class RutineRepository : IRutineRepository
    {


        private readonly DatabaseContext _databaseContext;

        public RutineRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<IEnumerable<string>> GetRutineStrAsync()
        {
            try
            {
                var rutine = await _databaseContext.Rutina.Select(x => x.ToString()).ToListAsync();
                return rutine;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Rutina>> GetRutineAsync()
        {
            try
            {
                var rutine = await _databaseContext.Rutina.ToListAsync();
                return rutine;
            }
            catch (Exception e)
            {
                var mesaj = $"{e.Message} {e.Data} {e.StackTrace}";
                return null;
            }
        }




        public async Task<Rutina> GetRutinaByIdAsync(int id)
        {
            try
            {
                var rutina = await _databaseContext.Rutina.FindAsync(id);
                return rutina;
            }
            catch (Exception e)
            {
                return null;
            }
        }






        public async Task<bool> AddRutinaAsync(Rutina rut)
        {
            try
            {
                var tracking = await _databaseContext.Rutina.AddAsync(rut);

                await _databaseContext.SaveChangesAsync();
                var isAdded = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Added;
                return isAdded;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public async Task<bool> UpdateRutinaAsync(Rutina rut)
        {
            try
            {
                var tracking = _databaseContext.Update(rut);

                await _databaseContext.SaveChangesAsync();
                var isModified = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Modified;
                return isModified;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public async Task<bool> RemoveRutinaAsync(int id)
        {
            try
            {
                var rut = await _databaseContext.Rutina.FindAsync(id);

                var tracking = _databaseContext.Remove(rut);

                await _databaseContext.SaveChangesAsync();
                var isDeleted = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Deleted;
                return isDeleted;
            }
            catch (Exception e)
            {
                return false;
            }
        }





        public async Task<IEnumerable<Rutina>> QueryRutineAsync(Func<Rutina, bool> predicate)
        {
            try
            {
                var rutine = _databaseContext.Rutina.Where(predicate);
                return rutine.ToList();
            }
            catch (Exception e)
            {
                return null;
            }


        }

    
    }
}
