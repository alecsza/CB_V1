using CB_V1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CB_Database
{
    public class ActiuniRepository : IActiuniRepository
    {


        private readonly DatabaseContext _databaseContext;

        public ActiuniRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<IEnumerable<string>> GetActiuniStrAsync()
        {
            try
            {
                var actiuni = await _databaseContext.Actiune.Select(x => x.ToString()).ToListAsync();
                return actiuni;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Actiune>> GetActiuniAsync()
        {
            try
            {
                var actiuni = await _databaseContext.Actiune.ToListAsync();
                return actiuni;
            }
            catch (Exception e)
            {
                var mesaj = $"{e.Message} {e.Data} {e.StackTrace}";
                return null;
            }
        }




        public async Task<Actiune> GetActiuneByIdAsync(int id)
        {
            try
            {
                var actiune = await _databaseContext.Actiune.FindAsync(id);
                return actiune;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Actiune> GetActiuneByNameAsync(string den)
        {
            try
            {
                var actiune = await _databaseContext.Actiune.FindAsync(den);
                return actiune;
            }
            catch (Exception e)
            {
                return null;
            }
        }






        public async Task<bool> AddActiuneAsync(Actiune act)
        {
            try
            {
                var tracking = await _databaseContext.Actiune.AddAsync(act);

                await _databaseContext.SaveChangesAsync();
                var isAdded = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Added;
                return isAdded;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public async Task<bool> UpdateActiuneAsync(Actiune act)
        {
            try
            {
                var tracking = _databaseContext.Update(act);

                await _databaseContext.SaveChangesAsync();
                var isModified = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Modified;
                return isModified;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public async Task<bool> RemoveActiuneAsync(int id)
        {
            try
            {
                var act = await _databaseContext.Actiune.FindAsync(id);

                var tracking = _databaseContext.Remove(act);

                await _databaseContext.SaveChangesAsync();
                var isDeleted = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Deleted;
                return isDeleted;
            }
            catch (Exception e)
            {
                return false;
            }
        }





        public async Task<IEnumerable<Actiune>> QueryActiuniAsync(Func<Actiune, bool> predicate)
        {
            try
            {
                var actiuni = _databaseContext.Actiune.Where(predicate);
                return actiuni.ToList();
            }
            catch (Exception e)
            {
                return null;
            }


        }

   
    }
}

