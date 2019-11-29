using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataDetailsController : ControllerBase
    {
        private readonly DataDetailContext _context;

        public DataDetailsController(DataDetailContext context)
        {
            _context = context;
        }

        // GET: api/DataDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataDetails>>> GetDataDetails()
        {
            return await _context.DataDetails.ToListAsync();
        }

        // GET: api/DataDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataDetails>> GetDataDetails(int id)
        {
            var dataDetails = await _context.DataDetails.FindAsync(id);

            if (dataDetails == null)
            {
                return NotFound();
            }

            return dataDetails;
        }

        // PUT: api/DataDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataDetails(int id, DataDetails dataDetails)
        {
            if (id != dataDetails.PMID)
            {
                return BadRequest();
            }

            _context.Entry(dataDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataDetailsExists(id))
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

        // POST: api/DataDetails
        [HttpPost]
        public async Task<ActionResult<DataDetails>> PostDataDetails(DataDetails dataDetails)
        {
            _context.DataDetails.Add(dataDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataDetails", new { id = dataDetails.PMID }, dataDetails);
        }

        // DELETE: api/DataDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataDetails>> DeleteDataDetails(int id)
        {
            var dataDetails = await _context.DataDetails.FindAsync(id);
            if (dataDetails == null)
            {
                return NotFound();
            }

            _context.DataDetails.Remove(dataDetails);
            await _context.SaveChangesAsync();

            return dataDetails;
        }

        private bool DataDetailsExists(int id)
        {
            return _context.DataDetails.Any(e => e.PMID == id);
        }
    }
}
