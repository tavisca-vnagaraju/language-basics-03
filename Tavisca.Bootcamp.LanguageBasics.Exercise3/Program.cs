using System;
using System.Linq;
using System.Collections.Generic;
namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            // Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int menuLength       = protein.Length;
            int[] totalCalories  = new int[menuLength];
            int[] selctedMenu    = new int[dietPlans.Length];
            for (int index = 0; index < menuLength; index++){
                totalCalories[index] = (protein[index]*5) + (carbs[index] *5) + (fat[index]*9);
            }
            for (int index = 0; index < dietPlans.Length; index++){
                selctedMenu[index] = GetMenuItem(dietPlans[index],protein,carbs,fat,totalCalories);
            }
            return selctedMenu;
        }
        public static int GetMenuItem(string dietPlan,int[] protein, int[] carbs, int[] fat,int[] totalCalories){
            List<int> menuItems = new List<int>();
            for (int index = 0; index < protein.Length; index++){
                menuItems.Add(index);
            }
            foreach (var c in dietPlan){
                switch(c)
                {
                    case 'P':
                        menuItems = GetIndex(protein, menuItems, GetMaxNum(protein, menuItems));
                        break;
                    case 'p':
                        menuItems = GetIndex(protein, menuItems, GetMinNum(protein, menuItems));
                        break;
                    case 'C':
                        menuItems = GetIndex(carbs, menuItems, GetMaxNum(carbs, menuItems));
                        break;
                    case 'c':
                        menuItems = GetIndex(carbs, menuItems, GetMinNum(carbs, menuItems));
                        break;
                    case 'F':
                        menuItems = GetIndex(fat, menuItems, GetMaxNum(fat, menuItems));
                        break;
                    case 'f':
                        menuItems = GetIndex(fat, menuItems, GetMinNum(fat, menuItems));
                        break;
                    case 'T':
                        menuItems = GetIndex(fat, menuItems, GetMinNum(fat, menuItems));
                        break;
                    case 't':
                        menuItems = GetIndex(totalCalories, menuItems, GetMinNum(totalCalories, menuItems));
                        break;
                }
            }
            return menuItems[0];
        }
        public static List<int> GetIndex(int[] dietItems, List<int> tempMenuItems, int selctedIndex) {
            List<int> menuItems = new List<int>();
            foreach (var menuItem in tempMenuItems) {
                if (dietItems[menuItem] == selctedIndex){
                    menuItems.Add(menuItem);
                } 
            }
            return menuItems;
        }
        public static int GetMaxNum(int[] dietItems, List<int> menuItems) {
            int maxNumber = dietItems[menuItems[0]];
            for (int index = 1; index < menuItems.Count; index++) {
                if (dietItems[menuItems[index]] > maxNumber){
                    maxNumber = dietItems[menuItems[index]];
                } 
            }
            return maxNumber;
        }
        public static int GetMinNum(int[] dietItems, List<int> menuItems) {
            int minNumber = dietItems[menuItems[0]];
            for (int index = 1; index < menuItems.Count; index++) {
                if (dietItems[menuItems[index]] < minNumber){
                    minNumber = dietItems[menuItems[index]];
                }
            }
            return minNumber;
        }
    }
}
