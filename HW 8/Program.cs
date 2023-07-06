using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HW_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Film> films = new List<Film>()
            {
              new Film { Name = "The Silence of the Lambs", Director ="Jonathan Demme" },
              new Film { Name = "The World's Fastest Indian", Director ="Roger Donaldson" },
              new Film { Name = "The Recruit", Director ="Roger Donaldson" }
            };

            List<Director> directors = new List<Director>()
            {
              new Director {Name="Jonathan Demme", Country="USA"},
              new Director {Name="Roger Donaldson", Country="New Zealand"},
            };

            List<string> strings = new List<string>() { "I", "like", "play", "board", "games", "!" };
            
            Console.WriteLine(strings.Aggregate((f, s) => f +=" " + s));
            
            Console.WriteLine(strings.Take(3).Aggregate((f, s) => f += " " + s) + " " + strings.Skip(3).Aggregate((f, s) => f += " " + s));
            

            Console.WriteLine(string.Join("\n",
                films.Select((n) => "Film: " + n.Name + ", Director: " + n.Director + " From " + 
                directors.Where(d => d.Name == n.Director ).Select(d => d.Country).FirstOrDefault()).ToArray()));
            
            Console.WriteLine(string.Join("", directors.Select(s => s.Name)
                .SelectMany(s => s + ": " + string.Join(", ", films.Where((d) => d.Director == s).Select(f => f.Name)) + "\n")));



        }
    }
    class Film
    {
        public string Name { get; set; }
        public string Director { get; set; }
    }
    class Director
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}