using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamenPar2.Models;

namespace ExamenPar2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkinsController : ControllerBase
    {
        // Variable de contexto de base de datos
        private readonly DbExamenContext _baseDatos;

        // Constructor
        public SkinsController(DbExamenContext baseDatos)
        {
            this._baseDatos = baseDatos;
        }

        // Método GET para listar todas las skins
        [HttpGet]
        [Route("ListaSkins")]
        public async Task<IActionResult> Lista()
        {
            var listaSkins = await _baseDatos.Skins.ToListAsync();
            return Ok(listaSkins);
        }

        // Método POST para agregar una nueva skin
        [HttpPost]
        [Route("AgregarSkin")]
        public async Task<IActionResult> Agregar([FromBody] Skin request)
        {
            await _baseDatos.Skins.AddAsync(request);
            await _baseDatos.SaveChangesAsync();
            return Ok(request);
        }

        // Método PUT para modificar una skin existente
        [HttpPut]
        [Route("ModificarSkin/{id:int}")]
        public async Task<IActionResult> Modificar(int id, [FromBody] Skin request)
        {
            if (request == null)
            {
                return BadRequest("Datos inválidos.");
            }

            var modificarSkin = await _baseDatos.Skins.FindAsync(id);

            if (modificarSkin == null)
            {
                return NotFound("La skin no existe.");
            }

            modificarSkin.Name = request.Name;
            modificarSkin.Description = request.Description;
            modificarSkin.Price = request.Price;
            modificarSkin.ImageUrl = request.ImageUrl;
            modificarSkin.Category = request.Category;

            try
            {
                await _baseDatos.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "Error interno del servidor.");
            }
            return Ok("Skin modificada exitosamente.");
        }

        // Método DELETE para eliminar una skin
        [HttpDelete]
        [Route("EliminarSkin/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var skinEliminar = await _baseDatos.Skins.FindAsync(id);

            if (skinEliminar == null)
            {
                return NotFound("La skin no existe.");
            }

            _baseDatos.Skins.Remove(skinEliminar);

            try
            {
                await _baseDatos.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return StatusCode(500, "Error interno del servidor.");
            }

            return Ok("Skin eliminada exitosamente.");
        }
    }
}
