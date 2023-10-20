using System;
using System.Linq;

namespace _02.Survivor
{
    public class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            char[][] field = new char[fieldSize][];

            for (int rows = 0; rows < field.GetLength(0); rows++)
            {
                char[] col = Console.ReadLine().Replace(" ", "").ToCharArray();
                field[rows] = col;
            }

            string command = string.Empty;
            int tokensCollected = 0;
            int opponentTokens = 0;
            while ((command = Console.ReadLine()) != "Gong")
            {
                
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);

                if (tokens.Length == 3)
                {
                    if (BoundsCheck(row, col, field))
                    {
                        (field, tokensCollected) = IsToken(row, col, field, tokensCollected);
                    }
                }
                else 
                {
                    string direction = tokens[3];
                    if (BoundsCheck(row, col, field))
                    {
                        (field, opponentTokens) = IsToken(row, col, field, opponentTokens);
                    
                        switch (direction)
                        { 
                        case "up":
                            for (int i = 0; i < 3; i++)
                            {
                                if (BoundsCheck(row - 1, col, field))
                                {
                                    row--;
                                    (field, opponentTokens) = IsToken(row, col, field, opponentTokens);
                                }
                            }

                            break;
                        case "down":
                            for (int i = 0; i < 3; i++)
                            {
                                if (BoundsCheck(row + 1, col, field))
                                {
                                    row++;
                                    (field, opponentTokens) = IsToken(row, col, field, opponentTokens);
                                }
                            }
                            break;
                        case "right":
                            for (int i = 0; i < 3; i++)
                            {
                                if (BoundsCheck(row, col + 1, field))
                                {
                                    col++;
                                    (field, opponentTokens) = IsToken(row, col, field, opponentTokens);
                                }
                            }
                            break;
                        case "left":
                            for (int i = 0; i < 3; i++)
                            {
                                if (BoundsCheck(row, col - 1, field))
                                {
                                    col--;
                                    (field, opponentTokens) = IsToken(row, col, field, opponentTokens);
                                }
                            }
                            break;
                        }
                    }
                }
            }
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    Console.Write($"{field[row][col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Collected tokens: {tokensCollected}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }
        public static Tuple< char[][], int> IsToken(int row, int col, char[][] field, int tokens)
        {
            if (field[row][col] == 'T')
            {
                tokens++;
                field[row][col] = '-';
            }
            return Tuple.Create(field, tokens);
        }
        public static bool BoundsCheck(int row, int col, char[][] matrix)
        {
            return (row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix[row].Length);
        }
    }
}
