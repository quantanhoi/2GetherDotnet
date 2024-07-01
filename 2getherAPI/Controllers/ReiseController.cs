using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using _2getherAPI.Models;

namespace _2getherAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReiseController : ControllerBase
{
    private readonly TravelAgencyContext _context;

    public ReiseController(TravelAgencyContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reise>>> GetReises()
    {
        return await _context.Reises
            .Include(r => r.Reiseziels)
            .Include(r => r.Teilnehmers)
            .ToListAsync();
    }
}
