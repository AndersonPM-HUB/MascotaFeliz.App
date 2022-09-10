using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    //clase que implementa la interfaz 
    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        /// <summary>
        /// Referencia al contexto de Dueno
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        

        public RepositorioVeterinario(AppContext appContext) //constructor recibe appcontext 
        {
            _appContext = appContext;
        }

        public Veterinario AddVeterinario(Veterinario v)
        {
            var Adicionar= _appContext.Veterinarios.Add(v);
            _appContext.SaveChanges();
            return Adicionar.Entity;
        }

        public void DeleteVeterinario(int idV)
        {
            var Encontrado = _appContext.Veterinarios.FirstOrDefault(d => d.Id == idV);
            if (Encontrado == null)
                return;
            _appContext.Veterinarios.Remove(Encontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<Veterinario> GetAllVeterinario()
        {
            return GetAllVeterinario_();
        }

        public IEnumerable<Veterinario> GetVeterinariosPorFiltro(string filtro)
        {
            var veterinario = GetAllVeterinario(); // Obtiene todos los saludos
            if (veterinario != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    veterinario = veterinario.Where(s => s.Nombres.Contains(filtro));
                }
            }
            return veterinario;
        }

        public IEnumerable<Veterinario> GetAllVeterinario_()
        {
            return _appContext.Veterinarios;
        }

        public Veterinario GetVeterinario(int idV)
        {
            return _appContext.Veterinarios.FirstOrDefault(d => d.Id == idV);
        }

        public Veterinario UpdateVeterinario(Veterinario v)
        {
            var Encontrado = _appContext.Veterinarios.FirstOrDefault(d => d.Id == v.Id);
            if (Encontrado != null)
            {
                Encontrado.Nombres = v.Nombres;
                Encontrado.Apellidos = v.Apellidos;
                Encontrado.Direccion = v.Direccion;
                Encontrado.Telefono = v.Telefono;
                Encontrado.TarjetaProfesional = v.TarjetaProfesional;
                _appContext.SaveChanges();
            }
            return Encontrado;
        }     
    }
}