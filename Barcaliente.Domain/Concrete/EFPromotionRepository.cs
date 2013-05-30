using Barcaliente.Domain.Abstract;
using Barcaliente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcaliente.Domain.Concrete
{
    public class EFPromotionRepository : IPromotionRepository
    {
        private Context context = new Context();
        public IQueryable<Promotion> Promotions
        {
            get { return context.Promotions; }
        }
    }
}
