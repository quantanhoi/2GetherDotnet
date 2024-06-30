using _2getherAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2getherAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ReisezielController : ControllerBase
{
    private readonly TravelAgencyContext _context;

    public ReisezielController(TravelAgencyContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reiseziel>>> GetReiseziels()
    {
        return await _context.Reiseziels.ToListAsync();
    }
}