using LogiSyncAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LogiSyncAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(LoginDto login)
        {
            if (login.Correo == "admin@logisync.cl" && login.Contrasena == "Admin123*")
            {
                return Ok(new
                {
                    mensaje = "Inicio de sesión exitoso",
                    usuario = "Administrador LogiSync",
                    correo = "admin@logisync.cl",
                    rol = "Administrador",
                    funcionalidades = new[]
                    {
                        "Gestionar operadores logísticos",
                        "Configurar estados normalizados",
                        "Configurar reglas de traducción",
                        "Gestionar usuarios",
                        "Consultar envíos"
                    }
                });
            }

            if (login.Correo == "usuario@logisync.cl" && login.Contrasena == "Usuario123*")
            {
                return Ok(new
                {
                    mensaje = "Inicio de sesión exitoso",
                    usuario = "Usuario Operativo",
                    correo = "usuario@logisync.cl",
                    rol = "Operador",
                    funcionalidades = new[]
                    {
                        "Registrar envíos",
                        "Ingresar estado original",
                        "Ver estado traducido",
                        "Consultar envíos",
                        "Adjuntar evidencias"
                    }
                });
            }

            return Unauthorized(new
            {
                mensaje = "Credenciales incorrectas"
            });
        }
    }
}