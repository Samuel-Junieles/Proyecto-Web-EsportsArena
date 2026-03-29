using EsportsArena.Data.Interface;
using EsportsArena.Entities.Models;
using EsportsArena.Logic.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PatrocinadoresApiController : ControllerBase
{
    private readonly IGenericDAO<Patrocinador> _dao; // Uso directo del DAO para ahorrar tiempo

    public PatrocinadoresApiController(IGenericDAO<Patrocinador> dao)
    {
        _dao = dao;
    }

    // GET: api/PatrocinadoresApi (Obtener todos)
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_dao.ObtenerTodos());
    }

    // POST: api/PatrocinadoresApi (Insertar/SET)
    [HttpPost]
    public IActionResult Post([FromBody] Patrocinador p)
    {
        _dao.Insertar(p);
        _dao.Guardar();
        return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
    }

    // PUT: api/PatrocinadoresApi (Actualizar)
    [HttpPut]
    public IActionResult Put([FromBody] Patrocinador p)
    {
        _dao.Actualizar(p);
        _dao.Guardar();
        return Ok(new { message = "Patrocinador actualizado con éxito" });
    }

    // DELETE: api/PatrocinadoresApi/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _dao.Eliminar(id);
        _dao.Guardar();
        return Ok(new { message = "Patrocinador eliminado" });
    }
}