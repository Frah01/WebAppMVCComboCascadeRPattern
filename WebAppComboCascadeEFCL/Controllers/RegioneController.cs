using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLCommon.Models;
using CLBusinessLayer;
namespace EsempioDa0.Controllers
{
    public class RegioneController : Controller
    {
        private readonly CorsoAcademyContext _context;
        private ManageBL oBl = null;
        public RegioneController(CorsoAcademyContext context)
        {

            _context = context;
        }

        // GET: Regione
        public async Task<IActionResult> Index()
        {
            List<CLCommon.Models.TRegione> listRegioni = null;

            oBl = new ManageBL(_context);
            listRegioni = await oBl.getAllRegioniAsync();

            return View(listRegioni);
        }

        // GET: Regione/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tRegione = await _context.TRegiones
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (tRegione == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tRegione);
        //}
        public async Task<IActionResult> Details(int? id)
        {
            TRegione oRegione = null;

            if (id == null)
            {
                return NotFound();
            }

            try
            {
                oBl = new ManageBL(_context);
                oRegione = await oBl.getDettaglioRegioneAsync(id);

            }
            catch (Exception ex)
            {
                //TODO MODIFICA DA APPORTARE AL sErr
                string sErr = string.Empty;
                if (ex.InnerException != null)
                {
                    sErr = ex.InnerException.Message;
                }
                else
                {
                    sErr = ex.Message;
                }
            }



            return View(oRegione);
        }

        // GET: Regione/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: Regione/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Nome,IsAutonoma,NumAbitanti")] TRegione tRegione)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(tRegione);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tRegione);
        //}

        // POST: Regione/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,IsAutonoma,NumAbitanti")] TRegione tRegione)
        {
            if (ModelState.IsValid)
            {
                Boolean isAdded = false;
                try
                {
                    oBl = new ManageBL(_context);
                    isAdded = await oBl.insRegioneAsync(tRegione);



                }
                catch (Exception ex)
                {
                    //TODO: Leggera modifica da apportare al sErr
                    string sErr = string.Empty;
                    if (ex.InnerException != null)
                    {
                        sErr = ex.InnerException.Message;
                    }
                    else
                    {
                        sErr = ex.Message;
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Regione/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tRegione = await _context.TRegiones.FindAsync(id);
            if (tRegione == null)
            {
                return NotFound();
            }
            return View(tRegione);
        }

        // POST: Regione/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,IsAutonoma,NumAbitanti")] TRegione tRegione)
        {
            if (id != tRegione.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Boolean isUpdated = false;
                try
                {
                    oBl = new ManageBL(_context);
                    isUpdated = await oBl.updRegioneAsync(tRegione);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TRegioneExists(tRegione.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tRegione);
        }

        // GET: Regione/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tRegione = await _context.TRegiones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tRegione == null)
            {
                return NotFound();
            }

            return View(tRegione);
        }

        // POST: Regione/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tRegione = await _context.TRegiones.FindAsync(id);
            if (tRegione != null)
            {
                _context.TRegiones.Remove(tRegione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool TRegioneExists(int id)
        {
            return _context.TRegiones.Any(e => e.Id == id);
        }
    }
}
