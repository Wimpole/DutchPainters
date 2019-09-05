using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchPainters.Models
{
    public class PaintingRepository
    {
        private readonly AppDbContext _context;

        public PaintingRepository(AppDbContext context)
        {
            _context = context;
        }

        internal List<Painting> GetAllPaintings()
        {
            return _context.Painting.ToList();
        }

        internal Painting GetPaintingById(int? id)
        {
            return _context.Painting.FirstOrDefault(m => m.Id == id);
        }

        internal void Add(Painting painting)
        {
            _context.Add(painting);
            _context.SaveChanges();
        }

        internal void UpdatePainting(Painting painting)
        {
            _context.Update(painting);
            _context.SaveChanges();
        }

        internal void Delete(Painting painting)
        {
            _context.Painting.Remove(painting);
            _context.SaveChanges();
        }

        internal IEnumerable GetAllPainters()
        {
            return _context.Painter.ToList();
        }

        internal Painter GetPainterById(int id)
        {
            return _context.Painter.FirstOrDefault(x => x.Id == id);
        }
    }
}
