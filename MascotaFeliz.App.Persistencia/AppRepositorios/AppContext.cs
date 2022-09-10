using Microsoft.EntityFrameworkCore; //import
using MascotaFeliz.App.Dominio;//clases 

namespace MascotaFeliz.App.Persistencia
{ //clase que permite mapeo de datos 
    public class AppContext : DbContext //herenda de una clase para la conexion DBCONTEXT
    {
        //creacion de las tablas en la BD
        public DbSet<Persona> Personas {get;set;} //orm de Entitiframework xcadaclase = dbset
        public DbSet<Veterinario> Veterinarios{get;set;} 
        public DbSet<Dueno> Duenos {get;set;} 
        public DbSet<VisitaPyP> VisitasPyP {get;set;} 
        public DbSet<Historia> Historias {get;set;} 
        public DbSet<Mascota> Mascotas {get;set;} 


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //Metodo para configuracion
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = MascotaFelizData");
            }
        }
    }
}