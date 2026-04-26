using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CobbleCompendium.Server.Models.Items;
using CobbleCompendium.Server.Models;

namespace CobbleCompendium.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CobblemonController(CobblemonContext context) : ControllerBase
    {
        private readonly CobblemonContext _context = context;

        // GET: api/Cobblemon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cobblemon>>> GetCobblemonItems()
        {
            return await _context.Cobblemons.ToListAsync();
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Cobblemon>> GetCobblemonByName(string name)
        {
            var cobblemon = _context.Cobblemons.SingleOrDefault(cobblemon => cobblemon.Name == name);
            if (cobblemon is null) return NotFound();
            return Ok(cobblemon);
        }
    }
}
