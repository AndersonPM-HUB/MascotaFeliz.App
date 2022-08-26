using System; //import 
namespace MascotaFeliz.App.Dominio //paquetes
{

    public class Mascota{

        public int Id { get; set; }
        public string nombre { get; set; }
        public string color { get; set; }
        public string especie { get; set; }
        public string raza { get; set; }

        public Dueno propietario { get; set; } //agragacion 
        public Veterinario veterinario { get; set;} //agregacion 
        public Historia historia { get; set;} // composicion


    }
}