using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchPainters.Models
{
    public class Painter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Epoch Epoch { get; set; }
        public List<Painting> Paintings {get; set; }
        public string Bio { get; set; }
        public string PortraitURL { get; set; }
    }
}
