using CB_V1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CB_Database
{
    public class UtilizatoriRepository : IUtilizatoriRepository
    {


        private readonly DatabaseContext _databaseContext;

        public UtilizatoriRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<IEnumerable<string>> GetUtilizatoriStrAsync()
        {
            try
            {
                var utilizatori = await _databaseContext.Utilizator.Select(x => x.ToString()).ToListAsync();
                return utilizatori;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Utilizator>> GetUtilizatoriAsync()
        {
            try
            {
                var utilizatori = await _databaseContext.Utilizator.ToListAsync();
                return utilizatori;
            }
            catch (Exception e)
            {
                var mesaj = $"{e.Message} {e.Data} {e.StackTrace}";
                return null;
            }
        }




        public async Task<Utilizator> GetUtilizatorByIdAsync(int id)
        {
            try
            {
                var utilizator = await _databaseContext.Utilizator.FindAsync(id);
                return utilizator;
            }
            catch (Exception e)
            {
                return null;
            }
        }






        public async Task<bool> AddUtilizatorAsync(Utilizator util)
        {
            try
            {
                var tracking = await _databaseContext.Utilizator.AddAsync(util);

                await _databaseContext.SaveChangesAsync();
                var isAdded = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Added;
                return isAdded;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public async Task<bool> UpdateUtilizatorAsync(Utilizator util)
        {
            try
            {
                var tracking = _databaseContext.Update(util);

                await _databaseContext.SaveChangesAsync();
                var isModified = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Modified;
                return isModified;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public async Task<bool> RemoveUtilizatorAsync(int id)
        {
            try
            {
                var util = await _databaseContext.Utilizator.FindAsync(id);

                var tracking = _databaseContext.Remove(util);

                await _databaseContext.SaveChangesAsync();
                var isDeleted = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Deleted;
                return isDeleted;
            }
            catch (Exception e)
            {
                return false;
            }
        }





        public async Task<IEnumerable<Utilizator>> QueryUtilizatoriAsync(Func<Utilizator, bool> predicate)
        {
            try
            {
                var utilizatori = _databaseContext.Utilizator.Where(predicate);
                return utilizatori.ToList();
            }
            catch (Exception e)
            {
                return null;
            }


        }

    }
}
