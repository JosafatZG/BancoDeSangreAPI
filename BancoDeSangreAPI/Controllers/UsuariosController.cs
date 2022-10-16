using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BancoDeSangreAPI.Context;
using BancoDeSangreAPI.Model;
using System.Text;
using System.Security.Cryptography;
using BancoDeSangreAPI.Dto;
using BancoDeSangreAPI.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace BancoDeSangreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IEmailSender _emailSender;

        public UsuariosController(AppDbContext context,
                                      IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }
        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario([FromQuery] int id, [FromQuery] UsuarioEditDTO usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            var userToEdit = await _context.Usuario.FindAsync(id);
            userToEdit.NombreUsuario = usuario.NombreUsuario;
            userToEdit.Correo = usuario.Correo;

            _context.Entry(userToEdit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            var pass = Hash(usuario.Pwd);
            usuario.Pwd = pass;
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        
        [HttpGet("Login")]
        public async Task<ActionResult<Usuario>> Login([FromQuery] UsuarioDTO usuario)
        {
            return (await _context.Usuario.FromSqlRaw("CALL sp_Login({0}, {1})", usuario.NombreUsuario, Hash(usuario.Pwd)).ToListAsync()).FirstOrDefault();
        }
        [HttpGet("SendConfirmationNumber")]
        public async Task<ActionResult<bool>> SendConfirmationNumber([FromQuery] string correo)
        {
            var flag = false;
            var exists = _context.Usuario.Any(e => e.Correo == correo);
            if (exists)
            {
                var user = (await _context.Usuario.Where(u => u.Correo == correo).ToListAsync()).First();
                var code = RandomString(6);
                EmailTemplate template = new EmailTemplate()
                {
                    Title = "Recuperar contraseña",
                    MailInfo = "info.fleeter.manager@gmail.com",
                    Headline = "¿Olvidaste tu contraseña?",
                    Message = "Reestablece tu contraseña desde la app móvil\nColoca el siguiente código en la app:",
                    Phone = "+503 7777-7777",
                    GetInTouch = "Mantente en contacto con nosotros",
                    Thanks = "¡Gracias por ser parte de Banco de Sangre SA de CV!",
                    Link = code
                };
                try
                {
                    user.CodigoRecuperacion = code;
                    await _context.SaveChangesAsync();
                    await ((EmailSender)_emailSender).SendEmailAsync(correo, template);
                    flag = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return flag;
        }
        [HttpGet("CheckConfirmationNumber")]
        public async Task<ActionResult<bool>> CheckConfirmationNumber([FromQuery] string correo, [FromQuery] string codigoRecuperacion)
        {
            var flag = false;
            var exists = _context.Usuario.Any(e => e.Correo == correo);
            if (exists)
            {
                var user = (await _context.Usuario.Where(u => u.Correo == correo).ToListAsync()).First();
                if (user.CodigoRecuperacion == codigoRecuperacion)
                    flag = true;
            }

            return flag;
        }
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromQuery] UsuarioChangePassDTO usuario)
        {
            var userToEdit = await _context.Usuario.FirstOrDefaultAsync(u => u.Correo == usuario.Correo);
            if(userToEdit == null)
            {
                return BadRequest();
            }

            userToEdit.Pwd = Hash(usuario.Pwd);

            _context.Entry(userToEdit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(userToEdit.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
        private static string Hash(string input)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }
        private static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}