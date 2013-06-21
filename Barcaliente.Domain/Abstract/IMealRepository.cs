using System.Linq;
using Barcaliente.Domain.Entities;

namespace Barcaliente.Domain.Abstract
{
    public interface IMealRepository
    {
        IQueryable<Meal> Meals { get; }
        bool Save(Meal meal);
        bool Delete(int mealId);
        bool Edit(string stringMealId, string value, string propertyToUpdate);
    }
}
