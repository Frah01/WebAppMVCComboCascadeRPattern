using CLCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace CLDataLayer
{
    public class ManageDL
    {
        private readonly CorsoAcademyContext _context;
        public ManageDL(CorsoAcademyContext context)
        {
            _context = context;
        }
        public async Task<List<TRegione>> getAllRegioniAsync()
        {
            List<TRegione> listRegioni = new List<TRegione>();
            listRegioni = await _context.TRegiones.ToListAsync();


            return listRegioni;
        }
        public async Task<TRegione> getDettaglioRegioneAsync(int? id)
        {
            TRegione oReg = null;
            oReg = await _context.TRegiones.FirstOrDefaultAsync(m => m.Id == id);
            return oReg;
        }

        public async Task<Boolean> insRegioneAsync(TRegione tRegione)
        {
            Boolean isAdded = false;
            _context.Add(tRegione);
            //0 = false   , 1 = true
            int ret = await _context.SaveChangesAsync();
            isAdded = Convert.ToBoolean(ret);
            return isAdded;
        }

        public async Task<TRegione> selRegioneAsync(int? id)
        {
            TRegione oReg = null;
            oReg = await _context.TRegiones.FindAsync(id);
            return oReg;
        }

        public async Task<Boolean> updRegioneAsync(TRegione tRegione)
        {
            Boolean isUpdated = false;
            _context.Update(tRegione);
            int ret = await _context.SaveChangesAsync();
            isUpdated = Convert.ToBoolean(ret);
            return isUpdated;
        }

        public async Task<Boolean> delRegioneAsync(int? id)
        {
            Boolean isDeleted = false;
            //DELETE
            int ret = await _context.SaveChangesAsync();
            isDeleted = Convert.ToBoolean(ret);
            return isDeleted;
        }

        public async Task<Boolean> manageDelRegione(int id)
        {
            Boolean isDeleted = false;
            var tRegione = await _context.TRegiones.FindAsync(id);
            if (tRegione != null)
            {
                _context.TRegiones.Remove(tRegione);
            }
            int ret = await _context.SaveChangesAsync();
            isDeleted = Convert.ToBoolean(ret);
            return isDeleted;
        }

        private async Task<bool> TRegioneExists(int id)
        {
            return await _context.TRegiones.AnyAsync(e => e.Id == id);
        }


    }
}
