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
            int menu_length       = protein.Length;
            int[] total_calories  = new int[menu_length];
            int[] selcted_menu    = new int[dietPlans.Length];
            for (int i = 0; i < menu_length; i++){
                total_calories[i] = (protein[i]*5) + (carbs[i] *5) + (fat[i]*9);
            }
            int j = 0;
            foreach (var item in dietPlans){
                selcted_menu[j] = getMenuItem(item,protein,carbs,fat,total_calories);
                j+=1;
            }
            return selcted_menu;
        }
        public static int getMenuItem(string item,int[] protein, int[] carbs, int[] fat,int[] total_calories){
            List<int> temp_items = new List<int>();
            for (int i = 0; i < protein.Length; i++){
                temp_items.Add(i);
            }
            foreach (var c in item){
                if(c == 'P'){
                    temp_items = getIndex(protein, temp_items, getMaxNum(protein, temp_items));
                }
                else if(c == 'p'){
                    temp_items = getIndex(protein, temp_items, getMinNum(protein, temp_items));
                }
                else if(c == 'C'){
                    temp_items = getIndex(carbs, temp_items, getMaxNum(carbs, temp_items));
                }
                else if(c == 'c'){
                    temp_items = getIndex(carbs, temp_items, getMinNum(carbs, temp_items));
                }
                else if(c == 'F'){
                    temp_items = getIndex(fat, temp_items, getMaxNum(fat, temp_items));
                }
                else if(c == 'f'){
                    temp_items = getIndex(fat, temp_items, getMinNum(fat, temp_items));
                }
                else if(c == 'T'){
                    temp_items = getIndex(fat, temp_items, getMinNum(fat, temp_items));
                }
                else if(c == 't'){
                    temp_items = getIndex(total_calories, temp_items, getMinNum(total_calories, temp_items));
                }
            }
            return temp_items[0];
        }
        public static List<int> getIndex(int[] array, List<int> temp, int num) {
            List<int> temp_items = new List<int>();
            foreach (var i in temp) {
                if (array[i] == num){
                    temp_items.Add(i);
                } 
            }
            return temp_items;
        }
        public static void printarrayay(int[] arrayay){
            foreach (var item in arrayay){
                System.Console.Write(item + " ");
            }
        }
        public static void printList(List<int> list){
            foreach (var item in list){
                System.Console.Write(item + " ");
            }
        }
        public static int getMaxNum(int[] array, List<int> temp_items) {
            int num = array[temp_items[0]];
            for (int i = 1; i < temp_items.Count; i++) {
                if (array[temp_items[i]] > num){
                    num = array[temp_items[i]];
                } 
            }
            return num;
        }
        public static int getMinNum(int[] array, List<int> temp_items) {
            int num = array[temp_items[0]];
            for (int i = 1; i < temp_items.Count; i++) {
                if (array[temp_items[i]] < num){
                    num = array[temp_items[i]];
                }
            }
            return num;
        }
    }
}
