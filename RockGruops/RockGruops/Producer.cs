using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockGruops
{
    class Producer:Human
    {
        public Producer(string name)
        {
            this.Name = name;
        }
        bool IsFooll;
        protected override void DoWork()
        {
            if (IsFooll)
            {
                Console.WriteLine("Naebuet");
            } 
            else
            {
                Console.WriteLine("Ne naebuet");
            }
        }
    }
}
