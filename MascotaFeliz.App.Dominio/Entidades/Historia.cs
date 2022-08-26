using System; 
using System.Collections.Generic;

namespace MascotaFeliz.App.Dominio //paquetes
{
    public class Historia{
        
        public int ID { get; set; }
        public DateTime fechaInicial { get; set; }
        public List<VisitaPyP> VisitasPyP { get; set;}
    }
}