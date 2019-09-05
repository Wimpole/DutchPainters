namespace DutchPainters.Models
{
    public class Painting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Painter Painter { get; set; }
        public int YearPainted { get; set; }
        public string ImageURL { get; set; }
    }
}