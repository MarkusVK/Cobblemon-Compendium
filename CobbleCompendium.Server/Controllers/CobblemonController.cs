using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CobbleCompendium.Server.Models;
using CobbleCompendium.Server.Utils;

namespace CobbleCompendium.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CobblemonController(CobblemonContext context) : ControllerBase
    {
        private readonly CobblemonContext _context = context;
        private readonly JsonFileReader fileReader = new();

        // GET: api/Cobblemon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CobblemonItem>>> GetCobblemonItems()
        {
            return await _context.CobblemonItems.ToListAsync();
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CobblemonItem>> GetCobblemonByName(string name)
        {
            var cobblemon = _context.CobblemonItems.SingleOrDefault(cobblemon => cobblemon.name == name);
            if (cobblemon is null) return NotFound();
            return Ok(cobblemon);
        }
    }
}
