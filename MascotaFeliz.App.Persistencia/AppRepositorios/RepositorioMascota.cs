using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    //clase que implementa la interfaz 
    public class RepositorioMascota : IRepositorioMascota
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
        

        public RepositorioMascota(AppContext appContext) //constructor recibe appcontext 
        {
            _appContext = appContext;
        }

        public Mascota AddMascota(Mascota m)
        {
            var Adicionar= _appContext.Mascotas.Add(m);
            _appContext.SaveChanges();
            return Adicionar.Entity;
        }

        public void DeleteMascota(int idV)
        {
            var Encontrado = _appContext.Mascotas.FirstOrDefault(d => d.Id == idV);
            if (Encontrado == null)
                return;
            _appContext.Mascotas.Remove(Encontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<Mascota> GetAllMascota()
        {
            return GetAllMascota_();
        }

        public IEnumerable<Mascota> GetMascotaPorFiltro(string filtro)
        {
            var mascota = GetAllMascota(); // Obtiene todos los saludos
            if (mascota != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    mascota = mascota.Where(s => s.nombre.Contains(filtro));
                }
            }
            return mascota;
        }

        public IEnumerable<Mascota> GetAllMascota_()
        {
            return _appContext.Mascotas;
        }

        public Mascota GetMascota(int idV)
        {
            return _appContext.Mascotas.FirstOrDefault(d => d.Id == idV);
        }

        public Mascota UpdateMascota(Mascota v)
        {
            var Encontrado = _appContext.Mascotas.FirstOrDefault(d => d.Id == v.Id);
            if (Encontrado != null)
            {
                Encontrado.nombre = v.nombre;
                Encontrado.color = v.color;
                Encontrado.especie = v.especie;
                Encontrado.raza = v.raza;
                Encontrado.propietario= v.propietario;
                Encontrado.veterinario = v.veterinario;
                Encontrado.historia = v.historia;
                _appContext.SaveChanges();
            }
            return Encontrado;
        }     
    }
}