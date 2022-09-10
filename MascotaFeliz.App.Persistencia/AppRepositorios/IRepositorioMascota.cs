using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioMascota//creacion de una interfaz define el comportamiento 
    {
        //lista elementos de la clase dueño 
        IEnumerable<Mascota> GetAllMascota();
        //metodos usados en la base de datos CRUD
        Mascota AddMascota(Mascota Mascota);
        Mascota UpdateMascota(Mascota Mascota);
        void DeleteMascota(int idMascota);
        Mascota GetMascota(int idMascota);
        //lista para filtrar filtro 
        IEnumerable<Mascota> GetMascotaPorFiltro(string filtro);
    }
}