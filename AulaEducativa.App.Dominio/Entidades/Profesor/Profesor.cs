﻿using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Profesor: EntidadBase, IAgregadoRaiz, IPersona
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        public bool ActualizarInformacion() {
            return false;
        }
    }
}