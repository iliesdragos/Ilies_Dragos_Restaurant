using Microsoft.AspNetCore.Mvc.RazorPages;
using Ilies_Dragos_Restaurant.Data;
using Ilies_Dragos_Restaurant.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ilies_Dragos_Restaurant.Models
{
    public class RestaurantCategoriesPageModel : PageModel
    {
        public List<AssignedRestaurantCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(
            Ilies_Dragos_RestaurantContext context,
            Restaurant restaurant)
        {
            var allCategories = context.RestaurantCategory;
            var restaurantCategories = new HashSet<int>(
                restaurant.RestaurantCategoryAssignments.Select(i => i.RestaurantCategoryID));

            AssignedCategoryDataList = new List<AssignedRestaurantCategoryData>();

            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedRestaurantCategoryData
                {
                    RestaurantCategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned =restaurantCategories.Contains(cat.ID)
                });
            }
        }


        public void UpdateRestaurantCategories(
            Ilies_Dragos_RestaurantContext context,
            string[] selectedCategories,
            Restaurant restaurantToUpdate)
        {
            if (selectedCategories == null)
            {
                restaurantToUpdate.RestaurantCategoryAssignments = new List<RestaurantCategoryAssignment>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var restaurantCategories = new HashSet<int>(
                restaurantToUpdate.RestaurantCategoryAssignments.Select(c => c.RestaurantCategoryID));

            foreach (var cat in context.RestaurantCategory)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!restaurantCategories.Contains(cat.ID))
                    {
                        restaurantToUpdate.RestaurantCategoryAssignments.Add(
                            new RestaurantCategoryAssignment
                            {
                                RestaurantID = restaurantToUpdate.ID,
                                RestaurantCategoryID = cat.ID
                            });
                    }
                }
                else
                {
                    if (restaurantCategories.Contains(cat.ID))
                    {
                        RestaurantCategoryAssignment categoryToRemove
                           = restaurantToUpdate
                           .RestaurantCategoryAssignments
                           .SingleOrDefault(i => i.RestaurantCategoryID == cat.ID);
                        context.Remove(categoryToRemove);
                    }
                }
            }
        }

    }
}
