//interfaz

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioDueno //creacion de una interfaz define el comportamiento 
    {
        //lista elementos de la clase dueño 
        IEnumerable<Dueno> GetAllDuenos();
        //metodos usados en la base de datos CRUD
        Dueno AddDueno(Dueno dueno);
        Dueno UpdateDueno(Dueno dueno);
        void DeleteDueno(int idDueno);
        Dueno GetDueno(int idDueno);
        //lista para filtrar filtro 
        IEnumerable<Dueno> GetDuenosPorFiltro(string filtro);
    }
}