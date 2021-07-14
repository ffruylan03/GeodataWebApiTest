using System.Threading.Tasks;
using Geodata.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Geodata.WebApi.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Person> Persons { get; set; }

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        void RollbackTransaction();
    }
}