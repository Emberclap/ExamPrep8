using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _02._The_Battle_of_The_Five_Armies
{
    public class Program
    {
        static void Main()
        {
            int armyArmor = int.Parse(Console.ReadLine());

            int fieldSize = int.Parse(Console.ReadLine());

            char[][] field = new char[fieldSize][];

            int currRowIndex = 0;
            int currColIndex = 0;

            for (int rows = 0; rows < field.GetLength(0); rows++)
            {
                char[] col = Console.ReadLine()
                    .ToArray();
                field[rows] = col;

                for (int cols = 0; cols < col.GetLength(0); cols++)
                {
                    if (col[cols] == 'A')
                    {
                        currRowIndex = rows;
                        currColIndex = cols;
                        field[rows][cols] = '-';
                    }
                }
            }
            
            bool armyIsDefeated = false;
            bool mordorReached = false;
            while (!armyIsDefeated && !mordorReached)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int orcArmyRow = int.Parse(tokens[1]);
                int orcArmyCol = int.Parse(tokens[2]);
                field[orcArmyRow][orcArmyCol] = 'O';

                
                switch (tokens[0])
                {
                     
                    case "up":
                        if (BoundsCheck(currRowIndex - 1, currColIndex, field))
                        {
                            armyArmor--; currRowIndex--;
                           (currRowIndex, currColIndex, field, armyArmor, armyIsDefeated, mordorReached) =
                                PositionActions(currRowIndex, currColIndex, field, armyArmor, armyIsDefeated, mordorReached);
                        }
                        else { armyArmor--; }
                        break;
                    case "down":
                        if (BoundsCheck(currRowIndex + 1, currColIndex, field))
                        {
                            currRowIndex++; armyArmor--;
                            (currRowIndex, currColIndex, field, armyArmor, armyIsDefeated, mordorReached) =
                                PositionActions(currRowIndex, currColIndex, field, armyArmor, armyIsDefeated, mordorReached);
                        }
                        else { armyArmor--; }
                        break;
                    case "right":
                        if (BoundsCheck(currRowIndex, currColIndex + 1, field))
                        {

                            currColIndex++; armyArmor--;
                            (currRowIndex, currColIndex, field, armyArmor, armyIsDefeated, mordorReached) =
                                PositionActions(currRowIndex, currColIndex, field, armyArmor, armyIsDefeated, mordorReached);
                        }
                        else { armyArmor--; }
                        break;
                    case "left":
                        if (BoundsCheck(currRowIndex, currColIndex - 1, field))
                        {
                            currColIndex--; armyArmor--;
                            (currRowIndex, currColIndex, field, armyArmor, armyIsDefeated, mordorReached) =
                                PositionActions(currRowIndex, currColIndex, field, armyArmor, armyIsDefeated, mordorReached);
                        }
                        else { armyArmor--; }
                        break;

                }
                if (armyArmor <= 0 && armyIsDefeated == false)
                {
                    Console.WriteLine($"The army was defeated at {currRowIndex};{currColIndex}.");
                    field[currRowIndex][currColIndex] = 'X';
                    armyIsDefeated = true;
                    break;
                }
            }
            
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    Console.Write($"{field[row][col]}");
                }
                Console.WriteLine();
            }


        }
        public static Tuple<int,int, char[][], int, bool, bool> 
            PositionActions (int row, int col, char[][] field, int armor, bool defeated, bool mordor)
        {
            defeated = false;
            mordor = false;
            if (field[row][col] == 'M')
            {

                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                field[row][col] = '-';
                mordor = true;
            }
            if (field[row][col] == 'O')
            {
                armor -= 2;
                if (armor > 0)
                {
                    field[row][col] = '-';
                }
                else
                {
                    Console.WriteLine($"The army was defeated at {row};{col}.");
                    field[row][col] = 'X';
                    defeated = true;
                }
            }
            
            return Tuple.Create(row, col, field, armor, defeated, mordor);
        } 
        public static bool BoundsCheck(int rowIndex, int colIndex, char[][] matrix)
        {
            if (rowIndex >= 0 && colIndex >= 0 && rowIndex < matrix.GetLength(0) && colIndex < matrix[rowIndex].Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
