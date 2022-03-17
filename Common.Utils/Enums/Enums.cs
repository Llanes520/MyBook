using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Enums
{
    public class Enums
    {
        public enum TypeState
        {
            //Usuario
            EstadoUsuario = 1,

            EstadoCitas = 2,
        }

        public enum State
        {
            //Usuario
            UsuarioActivo = 1,

            UsuarioInactivo = 2,
            UsuarioSuspendido = 3,

            //Citas
            CitaActiva = 4,

            CitaCancelada = 5,
            CitaFinalizada = 6,
        }

        public enum TypePermission
        {
            Usuarios = 1,
            Roles = 2,
            Permisos = 3,
            Veterinaria = 4,
            Estados = 5,
            Mascota = 6,
        }

        public enum Permission
        {
            //Usuarios
            CrearUsuarios = 1,

            ActualizarUsuarios = 2,
            EliminarUsuarios = 3,
            ConsultarUsuarios = 4,
            
            //Roles
            ActualizarRoles = 5,
            ConsultarRoles = 6,
            
            //Permisos
            ActualizarPermisos = 7,
            ConsultarPermisos = 8,
            DenegarPermisos = 9,
            
            //Estados
            ConsultarEstados = 10,
            ActualizarEstado = 11,
            
            //Mascota
            CrearMascota = 12,
            ActualizarMascota = 13,
            EliminarMascota = 14,
            ConsultarMascota = 15,
            
            //Veterinaria
            CrearCitas = 16,
            ConsultarCitas = 17,
            CancelarCitas = 18,
            ActualizarCitas = 19,
        }

        public enum RolUser
        {
            Administrador = 1,
            Veterinario = 2,
            Estandar = 3,
        }

        public enum Autores
        {
            Predeterminado = 1
        }
    }
}
