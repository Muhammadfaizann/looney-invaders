using System;
using System.Threading.Tasks;
using CocosSharp;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Extensions
{
    public static class CCSpriteSheetExtensions
    {
        public static Task<CCSpriteSheet> CCSpriteSheetFactoryMethodAsync(this object obj, object criteria)
        {
            Task <CCSpriteSheet> result = null;
            CCSpriteSheet sheet = null;
            Type criteriaType = criteria.GetType();
            if (obj != null && criteriaType == typeof(string))
            {
                result = Task.Run(() =>
                {
                    try
                    {
                        sheet = new CCSpriteSheet(criteria.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"|ON CCSpriteSheetFactoryMethodAsync| Exception: {ex.Message}");
                    }
                    return sheet;
                });
            }
            else if (obj == null)
            {
                Console.WriteLine("|ON CCSpriteSheetFactoryMethodAsync| Layer is null!");
            }

            return result;
        }
    }
}
