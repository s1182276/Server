namespace KeuzeWijzerApi.Models
{
    public class Leerroute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Module> Modules { get; set; }


        //public string Modules { get; set; }
    }
}
