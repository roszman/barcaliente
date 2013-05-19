using Barcaliente.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcaliente.Domain.Concrete
{
    public class EFMealRepository : IMealRepository
    {
        private Context context = new Context();
        public IQueryable<Meal> Meals
        {
            get { return context.Meals; }
        }
    }
}
