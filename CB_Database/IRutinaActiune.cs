using CB_V1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Database
{
    public class RutinaActiuneiRepository : IRutinaActiuniRepository
    {


        private readonly DatabaseContext _databaseContext;

        public RutinaActiuneiRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<IEnumerable<string>> GetRutinaActiuniStrAsync()
        {
            try
            {
                var rutine = await _databaseContext.RutinaActiune.Select(x => x.ToString()).ToListAsync();
                return rutine;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<RutinaActiune>> GetRutinaActiuniAsync()
        {
            try
            {
                var rutine = await _databaseContext.RutinaActiune.ToListAsync();
                return rutine;
            }
            catch (Exception e)
            {
                var mesaj = $"{e.Message} {e.Data} {e.StackTrace}";
                return null;
            }
        }




        public async Task<RutinaActiune> GetRutinaActiuneByIdAsync(int id)
        {
            try
            {
                var ra = await _databaseContext.RutinaActiune.FindAsync(id);
                return ra;
            }
            catch (Exception e)
            {
                return null;
            }
        }






        public async Task<bool> AddRutinaActiuneAsync(RutinaActiune ra)
        {
            try
            {
                var tracking = await _databaseContext.RutinaActiune.AddAsync(ra);

                await _databaseContext.SaveChangesAsync();
                var isAdded = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Added;
                return isAdded;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public async Task<bool> UpdateRutinaActiuneAsync(RutinaActiune ra)
        {
            try
            {
                var tracking = _databaseContext.Update(ra);

                await _databaseContext.SaveChangesAsync();
                var isModified = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Modified;
                return isModified;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public async Task<bool> RemoveRutinaActiuneAsync(int id)
        {
            try
            {
                var ra = await _databaseContext.RutinaActiune.FindAsync(id);

                var tracking = _databaseContext.Remove(ra);

                await _databaseContext.SaveChangesAsync();
                var isDeleted = tracking.State == Microsoft.EntityFrameworkCore.EntityState.Deleted;
                return isDeleted;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        public async Task<IEnumerable<RutinaActiune>> QueryRutinaActiuniAsync(Func<RutinaActiune, bool> predicate)
        {
            try
            {
                var rutine = _databaseContext.RutinaActiune.Where(predicate);
                return rutine.ToList();
            }
            catch (Exception e)
            {
                return null;
            }


        }

       
    }
}
