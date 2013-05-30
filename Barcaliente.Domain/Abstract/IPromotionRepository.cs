using Barcaliente.Domain.Entities;
using System.Linq;

namespace Barcaliente.Domain.Abstract
{
    public interface IPromotionRepository
    {
        IQueryable<Promotion> Promotions { get; }
    }
}
