using System;
using System.Collections.Generic;

namespace LightTheTorches
{
    class ExamProblemFour
    {
        static void Main(string[] args)
        {
            int roomCount = int.Parse(Console.ReadLine());
            string litPattern = Console.ReadLine();

            List<char> rooms = new List<char>();

            int index = 0;
            for (int i = 0; i < roomCount; i++)
            {
                if (index < litPattern.Length)
                {
                    rooms.Add(litPattern[index]);
                    index++;
                }
                else if (index == litPattern.Length)
                {
                    index = 0;
                    rooms.Add(litPattern[index]);
                    index++;
                }
            }

            int priestPosition = roomCount / 2;
            string movement = Console.ReadLine();
            int moveNumber = 0;
            
            while (movement != "END")
            {
                if (movement[0] == 'L')
                {
                    moveNumber =  int.Parse(movement.Substring(5)) + 1;
                    moveNumber *= -1;
                }
                else
                {
                    moveNumber = int.Parse(movement.Substring(6)) + 1;
                }

                if (priestPosition + moveNumber >= roomCount - 1 && priestPosition != roomCount - 1)
                {
                    priestPosition = roomCount - 1;
                    rooms[priestPosition] = rooms[priestPosition] == 'L' ? 'D' : 'L';
                }
                else if (priestPosition + moveNumber <= 0 && priestPosition != 0)
                {
                    priestPosition = 0;
                    rooms[priestPosition] = rooms[priestPosition] == 'L' ? 'D' : 'L';
                }
                else if (moveNumber != 0 && priestPosition + moveNumber > 0 && priestPosition + moveNumber < roomCount - 1)
                {
                    priestPosition += moveNumber;
                    rooms[priestPosition] = rooms[priestPosition] == 'L' ? 'D' : 'L';
                }

                movement = Console.ReadLine();
            }

            rooms.RemoveAll(c => c == 'L');

            Console.WriteLine(rooms.Count * 'D');
        }
    }
}
