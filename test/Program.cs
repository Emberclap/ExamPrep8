using System;

using System.Linq;



namespace _02.Survivor

{

    public class Program

    {
        static void Main(string[] args)

        {
            int rows = int.Parse(Console.ReadLine());
            char[][] field = new char[rows][];
            FillTheJaggedMatrix(field);
            var collectedTokens = CollectedTokens(field, out var opponentTokens);
            PrintMatrix(field);



            Console.WriteLine($"Collected tokens: {collectedTokens}");

            Console.WriteLine($"Opponent's tokens: {opponentTokens}");

        }
        public static int CollectedTokens(char[][] field, out int opponentTokens)
        {
            string command;
            int collectedTokens = 0;
            opponentTokens = 0;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                if (tokens.Length == 3)
                {
                    if (BoundsCheck(row, col, field))
                    {
                        (field, collectedTokens) = IsToken(row, col, field, collectedTokens);
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
            return collectedTokens;
        }
        private static void PrintMatrix(char[][] matrix)

        {
            foreach (var line in matrix)
            {
                var currentLine = string.Join(' ', line);

                Console.WriteLine(currentLine);

            }
        }
        public static bool BoundsCheck(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }
        public static void FillTheJaggedMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] tokensChars = Console.ReadLine().Replace(" ", "").ToCharArray();
                matrix[row] = tokensChars;
            }

        }
        public static Tuple<char[][], int> IsToken(int row, int col, char[][] field, int tokens)
        {
            if (field[row][col] == 'T')
            {
                tokens += 1;
                field[row][col] = '-';
            }
            return Tuple.Create(field, tokens);
        }
    }

}