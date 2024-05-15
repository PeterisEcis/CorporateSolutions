using CorporateSolutions.Data;
using Microsoft.AspNetCore.Mvc;

namespace CorporateSolutions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuditController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAudits([FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            var audits = _context.Audits
                .Where(a => (!from.HasValue || a.Date >= from) && (!to.HasValue || a.Date <= to))
                .OrderByDescending(a => a.Date)
                .Take(10)
                .ToList();
            return Ok(audits);
        }
    }

}
