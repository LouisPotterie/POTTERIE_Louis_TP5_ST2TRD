using System.Net.Http.Headers;

namespace csharp
{
    public class Sulfuras : Item
    {
        public string Name { get; set; } = "Sulfuras, Hand of Ragnaros";
        public int Quality { get; set; } = 80;
        
        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }  
    }
}