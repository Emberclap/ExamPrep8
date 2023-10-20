using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));

            Stack<int> freshness = new Stack<int>(Console.ReadLine()
                .Split(" ")
                .Select(int.Parse));

            Dictionary<string, int> dishes = new Dictionary<string, int>
            {
                { "Dipping sauce", 0 },
                { "Green salad", 0 },
                { "Chocolate cake", 0},
                { "Lobster", 0}
            };


            while (ingredients.Any() && freshness.Any())
            {
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }

                int totalLevel = freshness.Peek() * ingredients.Peek();

                if (totalLevel == 150)
                {
                    dishes["Dipping sauce"]++;
                    ingredients.Dequeue();
                    freshness.Pop();

                }
                else if (totalLevel == 250)
                {
                    dishes["Green salad"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (totalLevel == 300)
                {
                    dishes["Chocolate cake"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (totalLevel == 400)
                {
                    dishes["Lobster"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();
                    int tempIngredients = ingredients.Dequeue() + 5;
                    ingredients.Enqueue(tempIngredients);
                }
            }
            bool isSuccessful = true;
            foreach (var dish in dishes)
            {
                if (dish.Value == 0)
                {
                    isSuccessful = false;
                }
            }
            if (isSuccessful)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }
            foreach (var dish in dishes.OrderBy(x=>x.Key))
            {
                if(dish.Value > 0)
                {
                    Console.WriteLine($" # {dish.Key} --> {dish.Value}");
                }
            }
        }
    }
}
