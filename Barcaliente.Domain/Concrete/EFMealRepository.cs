using Barcaliente.Domain.Abstract;
using Barcaliente.Domain.Entities;
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


        public bool Save(Meal meal)
        {
            if (meal.MealID == 0)
            {
                context.Meals.Add(meal);
            }
            else
            {
                Meal mealtoUpdate = context.Meals.Find(meal.MealID);
                if (mealtoUpdate != null)
                {
                    mealtoUpdate.Name = meal.Name;
                    mealtoUpdate.Description = meal.Description;
                    mealtoUpdate.Category = meal.Category;
                    mealtoUpdate.Price = meal.Price;
                    mealtoUpdate.Order = 100;
                    mealtoUpdate.IsDeleted = false;
                }
            }
            return context.SaveChanges() > 0;
        }

        public bool Delete(int mealId)
        {
            Meal mealToDelete = context.Meals.Find(mealId);

            if (mealToDelete != null)
            {
                context.Meals.Remove(mealToDelete);
            }
            return context.SaveChanges() > 0;
        }


        public bool Edit(string stringMealId, string newValue, string propertyToUpdate)
        {
            int mealId;
            if (Int32.TryParse(stringMealId, out mealId))
            {
                Meal meal = context.Meals.Find(mealId);

                
                try
                {
                    Type propertyType = meal.GetType().GetProperty(propertyToUpdate).PropertyType;
                    if (propertyType == typeof(decimal))
                    {
                        meal.GetType().GetProperty(propertyToUpdate).SetValue(meal, decimal.Parse(newValue));
                    }
                    else
                    {
                        meal.GetType().GetProperty(propertyToUpdate).SetValue(meal, newValue);
                    }
                }
                catch
                {
                    throw;
                }
            }
            return context.SaveChanges() > 0;
        }
    }
}
