using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;


namespace MascotaFeliz.App.Consola
{
    class Program
    {
        //instanciando objeto de repoistorio dueño 
        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoV = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioMascota _repoM = new RepositorioMascota(new Persistencia.AppContext());
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //AddDueno(); 
            //AddVeterinario();
            listarDuenos();
            AddMascota();
        }

        //metodo para agregar un dueño 
        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                //Cedula = "1212",
                Nombres = "Anderson",
                Apellidos = "Pedroza",
                Direccion = "Pesca",
                Telefono = "123456789121",
                Correo = "anderpm@gmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }

        private static void listarDuenos(){

          var lista =  _repoDueno.GetAllDuenos();

        foreach (var d in lista)
        {
             Console.Write(d.Nombres + " ");
        }
        }

         private static void AddVeterinario()
        {
            var v = new Veterinario
            {
                //Cedula = "1212",
                Nombres = "Nilson",
                Apellidos = "Vargas",
                Direccion = "Bogota",
                Telefono = "1233121",
                TarjetaProfesional = "adwre12341"
            };
            _repoV.AddVeterinario(v);
        }

          //metodo para agregar un dueño 
        private static void AddMascota()
        {
            var m = new Mascota
            {
                //Cedula = "1212",
                nombre = "Kloe",
                color = "Cafe",
                especie = "Perro",
                raza = "criolla",
                //propietario = 2,
                //veterinario = 4,
                //historia = 1,
            };
            _repoM.AddMascota(m);
        }
    }
}
