using System;
using System.Collections.Generic;
using System.Linq;

// If I'm solving it for time I always prefer not to use bitwise operators.
// Maybe one day I will get comfortable enough with them... One day...

namespace FriendBits
{
    class ExamProblemFive
    {
        static void Main(string[] args)
        {
            List<char> loners = Convert.ToString(long.Parse(Console.ReadLine()), 2).ToCharArray().ToList();
            List<char> friends = new List<char>();

            int index = 0;
            int repetitions = 1;
            //bool noLoners = true;

            while (index < loners.Count - 1)
            {
                if (loners[index] == loners[index + 1])
                {
                    repetitions++;

                    if (index == loners.Count - 2 && repetitions > 1)
                    {
                        friends.AddRange(loners.GetRange(index, repetitions));
                        loners.RemoveRange(index, repetitions);

                        index -= repetitions;
                        repetitions = 1;                        
                    }
                }
                else
                {
                    if (repetitions > 1)
                    {
                        friends.AddRange(loners.GetRange((index - repetitions) + 1, repetitions));
                        loners.RemoveRange((index - repetitions) + 1, repetitions);

                        index -= repetitions;
                        repetitions = 1;                        
                    }                    
                }

                index++;
            }

            //List<char> temp = new List<char>();

            //if (noLoners)
            //{
            //    temp = loners;
            //    loners = friends;
            //    friends = temp;
            //}

            //Console.WriteLine(string.Join("", friends));
            //Console.WriteLine(string.Join("", loners));

            long friendsOutput = 0;
            long aloneOutput = 0;

            try
            {
                friendsOutput = Convert.ToInt64(string.Join("", friends), 2);
            }
            catch (Exception) { }

            try
            {
                aloneOutput = Convert.ToInt64(string.Join("", loners), 2);
            }
            catch (Exception) { }

            Console.WriteLine(friendsOutput);
            Console.WriteLine(aloneOutput);

        }
    }
}
