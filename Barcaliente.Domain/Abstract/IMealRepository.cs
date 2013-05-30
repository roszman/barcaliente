using Barcaliente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcaliente.Domain.Abstract
{
    public interface IMealRepository
    {
        IQueryable<Meal> Meals { get; }
    }
}
