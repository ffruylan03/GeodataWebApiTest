using System;
using System.Linq;
using System.Threading.Tasks;
using Geodata.WebApi.ApiModels.Persons;
using Geodata.WebApi.Data;
using Geodata.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Geodata.WebApi.Controllers
{
    public class PersonsController : BaseApiController
    {
        public PersonsController(IApplicationDbContext context) : base(context)
        {
        }

        [HttpGet()]
        [ProducesResponseType(typeof(PersonGetDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetListAsync()
        {
            try
            {
                var entity = await _context.Persons.AsNoTracking().ToListAsync();
                if (entity == null)
                    return StatusCode((int)StatusCodes.Status204NoContent, "No Data Available");

                var responseDto = entity.Select(e => new PersonGetDto()
                {
                    Name = !string.IsNullOrWhiteSpace(e.Name) ? e.Name : $"{e.FirstName} {e.MiddleName} {e.LastName}",
                    Age = e.Age,
                });

                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var errMsg = ex.Message;
                if (ex.InnerException != null)
                    errMsg = $"{errMsg} {ex.InnerException.Message}";

                return BadRequest(errMsg);
            }
        }

        [HttpPost()]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(PersonCreateDto request)
        {


            try
            {
                var entity = new Person()
                {
                    LastName = request.LastName,
                    FirstName = request.FirstName,
                    MiddleName = request.MiddleName,
                    Age = request.Age,
                };

                await _context.BeginTransactionAsync();
                await _context.Persons.AddAsync(entity);
                await _context.CommitTransactionAsync();

                return StatusCode((int)StatusCodes.Status200OK, entity.Id);
            }
            catch (Exception ex)
            {
                var errMsg = ex.Message;

                if (ex.InnerException != null)
                    errMsg = $"{errMsg} {ex.InnerException.Message}";

                _context.RollbackTransaction();
                return BadRequest(errMsg);
            }
        }
    }
}
