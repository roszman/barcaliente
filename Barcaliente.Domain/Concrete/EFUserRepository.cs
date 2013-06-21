using System.Linq;
using Barcaliente.Domain.Abstract;
using Barcaliente.Domain.Entities;

namespace Barcaliente.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private Context context = new Context();
        public IQueryable<User> Users
        {
            get { return context.Users; }
        }
    }
}
