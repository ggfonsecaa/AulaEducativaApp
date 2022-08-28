using AulaEducativa.App.Dominio.Interfaces;

namespace AulaEducativa.App.Dominio.Entidades
{
    public class Usuario : EntidadBase, IAgregadoRaiz
    {
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public int IdInstitucion { get; set; } 
        public virtual Institucion Institucion { get; set; }

        public bool IniciarSesion(){
            return false;
        }

        public bool RegistrarUsuario() {
            return false;
        }

        public void CerrarSesion() {
            
        }
    }
}