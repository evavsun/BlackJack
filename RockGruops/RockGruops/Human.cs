using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockGruops
{
   abstract  class Human
    {
        protected string Name { get; set; }
        protected string Instrument { get; set; }

        protected abstract void DoWork();
        
    }
}
