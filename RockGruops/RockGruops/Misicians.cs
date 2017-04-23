using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockGruops
{
    class Musicians : Human
    {
        public Musicians(string name, string instr)
        {
            Name = name;
            Instrument = instr;
        }

        protected override void DoWork()
        {
            Console.WriteLine("Play Music");
        }
    }
}
