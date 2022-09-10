using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioVeterinario //creacion de una interfaz define el comportamiento 
    {
        //lista elementos de la clase dueño 
        IEnumerable<Veterinario> GetAllVeterinario();
        //metodos usados en la base de datos CRUD
        Veterinario AddVeterinario(Veterinario v);
        Veterinario UpdateVeterinario(Veterinario v);
        void DeleteVeterinario(int idV);
        Veterinario GetVeterinario(int idV);
        //lista para filtrar filtro 
        IEnumerable<Veterinario> GetVeterinariosPorFiltro(string filtro);
    }
}