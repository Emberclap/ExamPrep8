using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _01._Birthday_Celebration
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            //CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Queue<int> guests = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            Stack<int> plates = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            int wastedFood = 0;

            while (plates.Any() && guests.Any())
            {
                int currentPlate = plates.Peek();
                int guestValue = guests.Peek();

                
                if (currentPlate >= guestValue)
                {
                    guests.Dequeue();
                    wastedFood += currentPlate - guestValue;
                    plates.Pop();
                
                }
                else if (guestValue > currentPlate)
                {
                    int tempValue = guestValue - currentPlate;
                    plates.Pop();
                    while (tempValue > 0)
                    {
                        currentPlate = plates.Peek();
                        tempValue -= currentPlate;
                        if (tempValue > 0)
                        {
                            plates.Pop() ;
                        }
                        else
                        {
                            wastedFood += Math.Abs(tempValue);
                            plates.Pop();
                        }
                    }
                    guests.Dequeue();
                }

            }
            if (plates.Any())
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            else if (guests.Any())
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
