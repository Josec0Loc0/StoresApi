using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoresApi.Data;
using StoresApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoresApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly StoresApiContext _context;

        public StoresController(StoresApiContext context)
        {
            _context = context;
        }

        // GET: api/stores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> GetStores()
        {
            // Obtiene todas las tiendas de la base de datos
            var stores = await _context.Stores.ToListAsync();
            return Ok(stores); // Devuelve todas las tiendas
        }

        // GET: api/stores/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetStore(int id)
        {
            var store = await _context.Stores.FindAsync(id);

            if (store == null)
            {
                return NotFound(); // Si no se encuentra la tienda con el ID dado
            }

            return Ok(store); // Devuelve la tienda encontrada
        }

        // POST: api/stores
        [HttpPost]
        public async Task<ActionResult<Store>> PostStore(Store store)
        {
            // Añade una nueva tienda a la base de datos
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStore), new { id = store.Id }, store);
        }

        // PUT: api/stores/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStore(int id, Store store)
        {
            if (id != store.Id)
            {
                return BadRequest(); // Si el ID de la URL no coincide con el ID de la tienda
            }

            _context.Entry(store).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(id))
                {
                    return NotFound(); // Si no se encuentra la tienda con el ID especificado
                }
                else
                {
                    throw; // Si ocurre un error en la concurrencia de la base de datos
                }
            }

            return NoContent(); // Devuelve un 204 No Content si todo está bien
        }

        // DELETE: api/stores/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            var store = await _context.Stores.FindAsync(id);
            if (store == null)
            {
                return NotFound(); // Si no se encuentra la tienda
            }

            _context.Stores.Remove(store); // Elimina la tienda de la base de datos
            await _context.SaveChangesAsync();

            return NoContent(); // Devuelve un 204 No Content si la eliminación fue exitosa
        }

        // Método privado para comprobar si la tienda existe
        private bool StoreExists(int id)
        {
            return _context.Stores.Any(e => e.Id == id);
        }
    }
}
