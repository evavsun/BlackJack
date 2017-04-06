using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            bool start = false;
            while(!start)
            {
                Console.WriteLine("Do you want to start a new game? Please, press \"Enter\" or \"Esc\" ");
                ConsoleKeyInfo key = Console.ReadKey();
                if(key.KeyChar==13)
                {
                    new Game();
                }
                else
                {
                    start = true;
                }
            }
        }
    }
}
