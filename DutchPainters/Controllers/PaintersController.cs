using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DutchPainters.Models;

namespace DutchPainters.Controllers
{
    public class PaintersController : Controller
    {
        private readonly PainterRepository _painterRepository;

        public PaintersController(PainterRepository painterRepository)
        {
            _painterRepository = painterRepository;
        }

        // GET: Painters
        public IActionResult Index()
        {
            return View(_painterRepository.GetAllPainters());
        }

        //GET: Painters/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painter =  _painterRepository.GetPainterById(id);

            //painter.Paintings = _painterRepository.GetAllPaintingsByPainter(painter);
           
            if (painter == null)
            {
                return NotFound();
            }

            return View(painter);
        }

        // GET: Painters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Painters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Bio,PortraitURL")] Painter painter)
        {
            if (ModelState.IsValid)
            {
                _painterRepository.AddPainter(painter);
                return RedirectToAction(nameof(Index));
            }
            return View(painter);
        }

        // GET: Painters/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painter = _painterRepository.GetPainterById(id);
            if (painter == null)
            {
                return NotFound();
            }
            return View(painter);
        }

        // POST: Painters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Bio,PortraitURL")] Painter painter)
        {
            if (id != painter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _painterRepository.Update(painter);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PainterExists(painter.Id))
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
            return View(painter);
        }

        // GET: Painters/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painter = _painterRepository.GetPainterById(id);
            if (painter == null)
            {
                return NotFound();
            }

            return View(painter);
        }

        // POST: Painters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var painter = _painterRepository.GetPainterById(id);
            _painterRepository.DeletePainter(painter);
            return RedirectToAction(nameof(Index));
        }

        private bool PainterExists(int id)
        {
            return _painterRepository.GetPainterById(id) != null;
        }
    }
}
