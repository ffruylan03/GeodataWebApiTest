using Geodata.WebApi.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Geodata.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IApplicationDbContext _context;
        public BaseApiController(IApplicationDbContext context)
        {
            _context = context;
        }
    }
}