using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    class Persons
    {
        static void Main(string[] args)
        {
            Person itsame = new Person("Mario", 30, "Mario@nintendo.co.jp");
            Person commanderSheperd = new Person("Jane Shepard", 32);
            //Person exceptionThrower = new Person("lol", 99, "lol");

            Console.WriteLine(itsame);
            Console.WriteLine(commanderSheperd);
        }
    }
}
