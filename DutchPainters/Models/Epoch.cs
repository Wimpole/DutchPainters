using System.Collections.Generic;

namespace DutchPainters.Models
{
    public class Epoch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public List<Painter> Painters { get; set; }
        public string Description { get; set; }

    }
}