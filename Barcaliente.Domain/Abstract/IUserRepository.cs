using System.Linq;
using Barcaliente.Domain.Entities;

namespace Barcaliente.Domain.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
    }
}
