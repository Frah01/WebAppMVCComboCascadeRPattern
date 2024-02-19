using CLCommon.Models;
using CLDataLayer;
using System.Security.AccessControl;

namespace CLBusinessLayer
{
    public class ManageBL
    {
        public readonly CorsoAcademyContext _context;

        public ManageBL(CorsoAcademyContext context)
        {
            _context = context;
        }

        public ManageDL oDL = null;

        public async Task<List<TRegione>> getAllRegioniAsync()
        {
            oDL = new ManageDL(_context);
            List<TRegione> listRegioni = await oDL.getAllRegioniAsync();

            listRegioni = await oDL.getAllRegioniAsync();
            return listRegioni;
        }

        public async Task<TRegione> getDettaglioRegioneAsync(int? id)
        {
            TRegione oReg = null;
            oDL = new ManageDL(_context);
            oReg = await oDL.getDettaglioRegioneAsync(id);
            return oReg;
        }

        public async Task<Boolean> insRegioneAsync(TRegione tRegione)
        {
            Boolean isAdded = false;
            oDL = new ManageDL(_context);
            isAdded = await oDL.insRegioneAsync(tRegione);
            return isAdded;
        }
        public async Task<TRegione> selRegioneAsync(int? id)
        {
            TRegione oReg = null;
            oDL = new ManageDL(_context);
            oReg = await oDL.selRegioneAsync(id);
            return oReg;
        }

        public async Task<Boolean> updRegioneAsync(TRegione tRegione)
        {
            Boolean isUpdated = false;
            oDL = new ManageDL(_context);
            isUpdated = await oDL.updRegioneAsync(tRegione);
            return isUpdated;
        }

        public async Task<Boolean> delRegioneAsync(int? id)
        {
            Boolean isDeleted = false;
            oDL = new ManageDL(_context);
            isDeleted = await oDL.delRegioneAsync(id);
            return isDeleted;
        }

        public async Task<Boolean> manageDelRegione(int id)
        {
            Boolean isDeleted = false;
            oDL = new ManageDL(_context);
            isDeleted = await oDL.manageDelRegione(id);
            return isDeleted;
        }

    }
}
