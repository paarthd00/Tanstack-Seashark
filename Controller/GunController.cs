using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GunApp.Models;

namespace GunApp.Controllers;

[ApiController]
[Route("api/[controller]")]


/*
controllers, react, routing, useQuery, useMutation, zod validation, 
*/


public class GunsController : ControllerBase
{
    private readonly DatabaseContext _context;

    public GunsController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Gun>>> GetGunItems()
    {
        return await _context.Guns.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Gun>> GetGunItem(int id)
    {
        var GunItem = await _context.Guns.FindAsync(id);

        if (GunItem == null)
        {
            return NotFound();
        }

        return GunItem;
    }

    [HttpPost]
    public async Task<ActionResult<Gun>> PostGunItem(Gun Gun)
    {
        _context.Guns.Add(Gun);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetGunItem), new { id = Gun.Id }, Gun);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutGunItem(int id, Gun Gun)
    {
        if (id != Gun.Id)
        {
            return BadRequest();
        }

        _context.Entry(Gun).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGunItem(int id)
    {
        var GunItem = await _context.Guns.FindAsync(id);
        if (GunItem == null)
        {
            return NotFound();
        }

        try
        {
            _context.Guns.Remove(GunItem);
            await _context.SaveChangesAsync();

        }
        catch (DbUpdateException)
        {
            return BadRequest();
        }

        return NoContent();
    }
}