using Microsoft.AspNetCore.Mvc;
using SocietyAgendor.API.Entities;
using SocietyAgendor.API.Models;
using SocietyAgendor.API.Services;
using System.Collections.Generic;

namespace SocietyAgendor.API.Controllers
{
    // TODO: RETORNAR 1 CARGO

    [Route("api/usuarios")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult GetAllUsuarios()
        {
            var result = new List<UsuarioModel>();
            var list = _usuarioRepository.GetAllUsuarios();

            foreach (var usuario in list)
            {
                result.Add(new UsuarioModel
                {
                    Usuario_Id = usuario.UsuarioId,
                    Usuario_Login = usuario.UsuarioLogin
                });
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateUsuario([FromBody] UsuarioModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = new Usuario
            {
                UsuarioLogin = model.Usuario_Login
            };

            var newUsuario = _usuarioRepository.CreateUsuario(usuario);

            model.Usuario_Id = newUsuario.UsuarioId;
            model.Usuario_Login = newUsuario.UsuarioLogin;

            return Ok(model);
        }

        [HttpPut("{usuarioId}")]
        public IActionResult UpdateUsuario(int cargoId, [FromBody] UsuarioModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = new Usuario
            {
                UsuarioId = model.Usuario_Id,
                UsuarioLogin = model.Usuario_Login
            };

            _usuarioRepository.UpdateUsuario(usuario);

            return NoContent();
        }        

        [HttpDelete("{usuarioId}")]
        public IActionResult DeleteUsuario(int usuarioId)
        {
            _usuarioRepository.DeleteUsuario(usuarioId);

            return NoContent();
        }

        [HttpPut("password/{usuarioId}")]
        public IActionResult UpdateUsuarioSenha(int usuarioId, [FromBody] UsuarioModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = new Usuario
            {
                UsuarioId = model.Usuario_Id,
                UsuarioSenha = model.Usuario_Senha
            };

            _usuarioRepository.UpdateUsuarioSenha(usuario);

            return NoContent();
        }
    }
}
