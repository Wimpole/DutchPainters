using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchPainters.Models
{
    public class PainterRepository
    {
        private readonly AppDbContext _context;

        public PainterRepository(AppDbContext context)
        {
            _context = context;
        }

        internal List<Painter> GetAllPainters()
        {
            return _context.Painter.ToList();
        }

        internal Painter GetPainterById(int? id)
        {
            return _context.Painter.Include(x => x.Paintings).Include(x => x.Epoch).FirstOrDefault(m => m.Id == id);
        }

        internal void AddPainter(Painter painter)
        {
            _context.Add(painter);
            _context.SaveChanges();
        }

        internal void Update(Painter painter)
        {
            _context.Update(painter);
            _context.SaveChanges();
        }

        internal void DeletePainter(Painter painter)
        {
            _context.Painter.Remove(painter);
            _context.SaveChanges();
        }

        internal List<Painting> GetAllPaintingsByPainter(Painter painter)
        {
            return _context.Painting.Where(x => x.Painter.Id == painter.Id).ToList();
        }

        internal IEnumerable<Epoch> GetAllEpochs()
        {
            return _context.Epoch.ToList();
        }

        internal Epoch GetEpochById(int id)
        {
            return _context.Epoch.FirstOrDefault(x => x.Id == id);
        }
    }
}
