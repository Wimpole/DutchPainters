using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DutchPainters.Models;
using DutchPainters.ViewModels;

namespace DutchPainters.Controllers
{
    public class PaintingsController : Controller
    {
        private readonly PaintingRepository _paintingRepository;

        public PaintingsController(PaintingRepository paintingRepository)
        {
            _paintingRepository = paintingRepository;
        }

        // GET: Paintings
        public IActionResult Index()
        {
            return View(_paintingRepository.GetAllPaintings());
        }

        // GET: Paintings/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painting = _paintingRepository.GetPaintingById(id);
            if (painting == null)
            {
                return NotFound();
            }

            return View(painting);
        }

        // GET: Paintings/Create
        public IActionResult Create()
        {
            var allPainters = new SelectList(_paintingRepository.GetAllPainters(), "Id", "Name");

            CreatePaintingVm viewModel = new CreatePaintingVm
            {
                AllPainters = allPainters
            };

            return View(viewModel);
        }

        // POST: Paintings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,YearPainted,ImageURL,Painter")] Painting painting)
        {
            if (ModelState.IsValid)
            {
                painting.Painter = _paintingRepository.GetPainterById(painting.Painter.Id);
                _paintingRepository.Add(painting);
                return RedirectToAction(nameof(Index));
            }
            return View(painting);
        }

        // GET: Paintings/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painting = _paintingRepository.GetPaintingById(id);
            if (painting == null)
            {
                return NotFound();
            }
            return View(painting);
        }

        // POST: Paintings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,YearPainted,ImageURL,Painter")] Painting painting)
        {
            if (id != painting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _paintingRepository.UpdatePainting(painting);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaintingExists(painting.Id))
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
            return View(painting);
        }

        // GET: Paintings/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painting = _paintingRepository.GetPaintingById(id);

            if (painting == null)
            {
                return NotFound();
            }

            return View(painting);
        }

        // POST: Paintings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var painting = _paintingRepository.GetPaintingById(id);
            _paintingRepository.Delete(painting);

            return RedirectToAction(nameof(Index));
        }

        private bool PaintingExists(int id)
        {
            return _paintingRepository.GetPaintingById(id) != null;
        }
    }
}
