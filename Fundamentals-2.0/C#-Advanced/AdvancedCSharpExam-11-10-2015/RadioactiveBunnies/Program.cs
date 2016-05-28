using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioactiveBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            char[][] field = new char[int.Parse(dimensions[0])][];
            for (int i = 0; i < field.Length; i++)
            {
                field[i] = Console.ReadLine().ToCharArray();
            }

            string moves = Console.ReadLine();
            bool playerWon = false;
            bool playerDead = false;
            int move = 0;
            int[] playerLocation = getPlayerLocation(field);

            while (playerDead == false && playerWon == false)
            {
                if (getPlayerLocation(field)[0] != -1)
                {
                    playerLocation = getPlayerLocation(field);
                }

                playerWon = movePlayer(moves[move], field, ref playerDead);
                expandBunnies(field, playerLocation, ref playerDead);
                move++;
                //printField(field);
            }

            printField(field);
            if (playerWon)
            {                
                Console.WriteLine($"won: {playerLocation[0]} {playerLocation[1]}");
            }
            else if (playerDead)
            {
                Console.WriteLine($"dead: {playerLocation[0]} {playerLocation[1]}");
            }
            
        }

        private static bool expandBunnies(char[][] field, int[] playerLocation, ref bool playerDad)
        {
            int fieldHeight = field.Length;
            int fieldWidth = field[0].Length;

            char[][] newField = new char[fieldHeight][];
            for (int i = 0; i < newField.Length; i++)
            {
                newField[i] = new char[fieldWidth];
            }

            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == 'B')
                    {
                        try
                        { newField[i - 1][j] = 'B'; }                            
                        catch (Exception){ }

                        try
                        { newField[i + 1][j] = 'B'; }
                        catch (Exception) { }

                        try
                        { newField[i][j - 1] = 'B'; }
                        catch (Exception) { }

                        try
                        { newField[i][j + 1] = 'B'; }
                        catch (Exception) { }
                    }
                }
            }

            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (newField[i][j] == 'B' || newField[i][j] == 'P')
                    {
                        field[i][j] = newField[i][j];
                    }
                }
            }

            return false;
        }

        private static bool movePlayer(char move, char[][] field, ref bool playerDead)
        {
            int[] playerLocation = new int[2];

            playerLocation = getPlayerLocation(field);
            
            if (playerLocation[0] == -1)
            {
                playerDead = true;
                return true;
            }

            try
            {
                if (move == 'R')
                {                    
                    field[playerLocation[0]][playerLocation[1] + 1] = 'P';
                    field[playerLocation[0]][playerLocation[1]] = '.';                        
                }
                else if (move == 'L')
                {
                    field[playerLocation[0]][playerLocation[1] - 1] = 'P';
                    field[playerLocation[0]][playerLocation[1]] = '.';                        
                }
                else if (move == 'D')
                {
                    field[playerLocation[0] + 1][playerLocation[1]] = 'P';
                    field[playerLocation[0]][playerLocation[1]] = '.';                        
                }
                else if (move == 'U')
                {
                    field[playerLocation[0] - 1][playerLocation[1]] = 'P';
                    field[playerLocation[0]][playerLocation[1]] = '.';                        
                }
            }
            catch (Exception)
            {
                field[playerLocation[0]][playerLocation[1]] = '.';
                return true;
            }

            return false;
        }

        private static int[] getPlayerLocation(char[][] field)
        {
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == 'P')
                    {
                        int[] location = { i, j };
                        return location;
                    }
                }
            }

            int[] doesntExist = { -1, -1 };
            return doesntExist;
        }

        private static void printField(char[][] field)
        {
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    Console.Write(field[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
