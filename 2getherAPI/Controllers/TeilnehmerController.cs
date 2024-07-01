using _2getherAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2getherAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class TeilnehmerController : ControllerBase
{
    private readonly TravelAgencyContext _context;

    public TeilnehmerController(TravelAgencyContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Teilnehmer>>> GetTeilnehmers()
    {
        return await _context.Teilnehmers.ToListAsync();
    }
}