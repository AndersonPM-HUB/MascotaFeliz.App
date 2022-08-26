using System; //import 
namespace MascotaFeliz.App.Dominio //paquetes
{

    public class VisitaPyP{

        public int ID { get; set; }
        public DateTime  fechaVisita { get; set; }
        public float Temperatura { get; set; }
        public float Peso { get; set; }
        public float FrecuenciaRespiratoria { get; set; }
        public float FrecuenciaCardiaca { get; set; }
        public string estadoAnimo { get; set; }
        public int ID_Veterinario { get; set; }
        public string recomendaciones { get; set; }
    }
}